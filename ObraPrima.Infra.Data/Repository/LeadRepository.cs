using Microsoft.EntityFrameworkCore;
using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Context.Models;
using ObraPrima.Domain.Contracts.Repositories;
using ObraPrima.Infra.Data.Data;

namespace ObraPrima.Infra.Data.Repository;

public class LeadRepository(AppDbContext appDbContext) : ILeadRepository
{
    public async Task<List<PlanModel>?> GetProposalActiveAsync(int? id)
    {
        var proposals = await appDbContext.Plans
            .Where(x =>
                !x.IsOptional &&
                !x.IsTasting &&
                x.Active &&
                !x.IsHidden
            ).Select(x => new PlanModel
            {
                PlanId = x.Id,
                Name = x.Name,
            }).ToListAsync();

        var quantities = await appDbContext.FunctionPlans
            .Where(x =>
                x.Plan != null &&
                !x.Plan.IsOptional &&
                !x.Plan.IsTasting &&
                x.Plan.Active &&
                !x.Plan.IsHidden &&
                x.Function != null && (
                    x.Function.Key.Equals("OP.FUNCAO.OBRAS.CADASTROOBRA")
                    || x.Function.Key.Equals("OP.FUNCAO.EXTRAS.ESPACODISCO")
                    || x.Function.Key.Equals("OP.FUNCAO.EXTRAS.USUARIOS"))
            ).Select(x => new
            {
                PlanId = x.Plan!.Id,
                Key = x.Function!.Key,
                Quantaty = x.QuanttityLimit
            }).GroupBy(x => x.PlanId).ToDictionaryAsync(x => x.Key, x => x.ToList());

        var dicPrices = await appDbContext.PeriodPlans
            .Where(x =>
                x.Plan != null &&
                !x.Plan.IsOptional &&
                !x.Plan.IsTasting &&
                x.Plan.Active &&
                !x.Plan.IsHidden
            ).Select(x => new
            {
                PlaId = x.Plan!.Id,
                Name = x.Name,
                Price = x.Price
            })
            .GroupBy(x => x.PlaId)
            .ToDictionaryAsync(x => x.Key, x => x.ToList());
        
        var dicOptionals = await appDbContext.OptionalPlans
            .Where(x =>
                x.Plan != null &&
                x.Plan.IsOptional &&
                !x.Plan.IsTasting &&
                x.Plan.Active &&
                !x.Plan.IsHidden &&
                x.PeriodPlan != null &&
                x.PeriodPlan.Name.Equals(PlanModel.Period.Annual) &&
                !(x.Plan.Id == 13 || x.Plan.Id == 22 || x.Plan.Id == 23)
            )
            .Select(x => new PlanModel.Optional()
            {
                ExtraId = x.PlanId,
                Name = x.Plan!.Name,
                PlanId = x.PeriodPlan!.PlanId,
                OptionalPrice = new PlanModel.Price()
                {
                    Monthly = x.Price
                }
            })
            .GroupBy(x => x.PlanId)
            .ToDictionaryAsync(x => x.Key, x => x.ToList());

        foreach (var proposal in proposals)
        {
            if (!quantities.ContainsKey(proposal.PlanId))
                continue;

            var planQuantities = quantities[proposal.PlanId];
            foreach (var quantaty in planQuantities)
            {
                switch (quantaty.Key)
                {
                    case "OP.FUNCAO.OBRAS.CADASTROOBRA":
                        proposal.QuantityProject = quantaty.Quantaty;
                        break;
                    case "OP.FUNCAO.EXTRAS.USUARIOS":
                        proposal.QuantityUser = quantaty.Quantaty;
                        break;
                    case "OP.FUNCAO.EXTRAS.ESPACODISCO":
                        proposal.QuantityDisk = quantaty.Quantaty;
                        break;
                }
            }
            
            var planPrice = dicPrices[proposal.PlanId];
            foreach (var price in planPrice)
            {
                switch (price.Name)
                {
                    case "Anual":
                        proposal.PlanPrice.Annual = price.Price!.Value;
                        break;
                    case "Semestral":
                        proposal.PlanPrice.SemiAnnual = price.Price!.Value;
                        break;
                    case "Trimestral":
                        proposal.PlanPrice.Quarterly = price.Price!.Value;
                        break;
                    case "Mensal":
                        proposal.PlanPrice.Monthly = price.Price!.Value;
                        break;
                }
            }
            
            if (!dicOptionals.ContainsKey(proposal.PlanId))
                continue;

            var optionals = dicOptionals[proposal.PlanId];
            proposal.Optionals ??= [];
            proposal.Optionals.AddRange(optionals);
        }
        
        return proposals;
    }

    public async Task<Lead?> GetLeadByName(string name)
    {
        var lead = await appDbContext.Leads
            .Include(x => x.Supplier)
            .Include(x => x.Proposal)
            .Where(x => x.CompanyName.Contains(name))
            .FirstOrDefaultAsync();
        
        if (lead is null)
            return null;
        
        var proposalHistories = await appDbContext.ProposalHistories
            .Where(x => lead.Proposal != null && x.ProposalId == lead.Proposal.Id).ToListAsync();
        
        if (lead.Proposal is null)
            return lead;
        
        lead.Proposal.ProposalHistories = proposalHistories;

        var proposalProducts = await appDbContext.ProposalProducts
            .Include(x => x.ProposalProductOptionals)
            .Where(x => lead.Proposal != null && x.ProposalId == lead.Proposal.Id)
            .FirstOrDefaultAsync();
        
        lead.Proposal.ProposalProduct = proposalProducts;

        return lead;
    }
}
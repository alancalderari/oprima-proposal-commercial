using ObraPrima.Application.DTOs.Lead;
using ObraPrima.Application.Mappings.Lead;
using ObraPrima.Application.Services.Contracts;
using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Contracts.Repositories;

namespace ObraPrima.Application.Services;

public class LeadService(ILeadRepository leadRepository) : ILeadService
{
    public async Task<ResultService<List<PlanDto>>> GetProposal(int id)
    {
        var proposals = await leadRepository.GetProposalActiveAsync(id);
        if (proposals.Count == 0)
            return ResultService.Fail<List<PlanDto>>("erro");
        
        var proposalDto = proposals.Select(x => new PlanDto().ToDto(x)).ToList();
        
        return ResultService.Ok(proposalDto);
    }

    public async Task<ResultService<LeadDto>> GetLeadByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return ResultService.Fail<LeadDto>("Name of company is invalid or empty");

        var lead = await leadRepository.GetLeadByName(name);

        return lead is null ? ResultService.Fail<LeadDto>("Lead not found or company name is invalid") : ResultService.Ok(lead.ToDto());
    }
}
using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Application.Mappings.Proposal;

public static class ProposalProductDtoMap
{
    public static ProposalProduct ToEntity(this ProposalProductDto proposalProductDto)
    {
        return new ProposalProduct
        {
            Id = proposalProductDto.Id ?? 0,
            PlanId = proposalProductDto.PlanId,
            Name = proposalProductDto.Name,
            Price = proposalProductDto.Price,
            PriceDiscount = proposalProductDto.PriceDiscount,
            MembershipRate = proposalProductDto.MembershipRate,
            MembershipRateDiscount = proposalProductDto.MembershipRateDiscount,
            Period = proposalProductDto.Period,
            ProposalProductOptionals = proposalProductDto.ProposalProductOptionals.Select(x => x.ToEntity()).ToList()
        };
    }
    public static ProposalProductDto ToDto(this Domain.Context.Entities.ProposalProduct proposalProduct)
    {
        return new ProposalProductDto(
            proposalProduct.Id,
            proposalProduct.PlanId,
            proposalProduct.Name,
            proposalProduct.Price,
            proposalProduct.PriceDiscount,
            proposalProduct.MembershipRate,
            proposalProduct.MembershipRateDiscount,
            proposalProduct.Period,
            proposalProduct.ProposalProductOptionals.Select(x => x.ToDto()).ToList()
        );
    }
}
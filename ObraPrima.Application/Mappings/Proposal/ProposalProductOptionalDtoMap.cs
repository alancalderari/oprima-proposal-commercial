using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Application.Mappings.Proposal;

public static class ProposalProductOptionalDtoMap
{
    public static ProposalProductOptional ToEntity(this ProposalProductOptionalDto proposalProductOptionalDto)
    {
        return new ProposalProductOptional
        {
            PlanId = proposalProductOptionalDto.PlanId,
            Name = proposalProductOptionalDto.Name,
            Price = proposalProductOptionalDto.Price,
            PriceDiscount = proposalProductOptionalDto.PriceDiscount
        };
    }
    public static ProposalProductOptionalDto ToDto(this Domain.Context.Entities.ProposalProductOptional proposalProductOptional)
    {
        return new ProposalProductOptionalDto(
            proposalProductOptional.PlanId,
            proposalProductOptional.Name,
            proposalProductOptional.Price,
            proposalProductOptional.PriceDiscount
        );
    }
}
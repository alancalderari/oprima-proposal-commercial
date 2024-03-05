namespace ObraPrima.Application.DTOs.Proposal;

public record ProposalProductOptionalDto(
    int PlanId,
    string Name,
    decimal Price,
    decimal PriceDiscount);
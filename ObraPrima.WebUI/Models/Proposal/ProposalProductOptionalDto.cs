namespace ObraPrima.WebUI.Models.Proposal;

public record ProposalProductOptionalDto(
    int PlanId,
    string Name,
    decimal Price,
    decimal PriceDiscount);
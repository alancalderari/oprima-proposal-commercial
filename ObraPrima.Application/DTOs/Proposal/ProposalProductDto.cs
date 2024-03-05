namespace ObraPrima.Application.DTOs.Proposal;

public record ProposalProductDto(
    int? Id,
    int PlanId, 
    string Name, 
    decimal Price, 
    decimal PriceDiscount, 
    decimal MembershipRate, 
    decimal MembershipRateDiscount, 
    int Period,
    List<ProposalProductOptionalDto> ProposalProductOptionals);
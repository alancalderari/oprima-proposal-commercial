namespace ObraPrima.Application.DTOs.Proposal;


public record ProposalDto(
    int? Id,
    int LeadId,
    ProposalProductDto ProposalProduct,
    List<ProposalHistoryDto>? ProposalHistories);
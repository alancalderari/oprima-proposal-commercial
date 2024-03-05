namespace ObraPrima.WebUI.Models.Proposal;

public record ProposalDto(
    int? Id,
    int LeadId,
    ProposalProductDto ProposalProduct,
    List<ProposalHistoryDto>? ProposalHistories);
namespace ObraPrima.WebUI.Models.Proposal;

public record ProposalHistoryDto(int? Id, int ProposalId, int EventType, string Description);
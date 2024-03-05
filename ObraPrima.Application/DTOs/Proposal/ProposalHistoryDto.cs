namespace ObraPrima.Application.DTOs.Proposal;

public record ProposalHistoryDto(int? Id, int ProposalId, int EventType, string Description);
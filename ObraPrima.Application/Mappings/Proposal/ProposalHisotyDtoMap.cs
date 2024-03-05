using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Application.Mappings.Proposal;

public static class ProposalHisotyDtoMap
{
    public static ProposalHistory ToEntity(this ProposalHistoryDto proposalHistoryDto)
    {
        return new ProposalHistory
        {
            Id = proposalHistoryDto.Id ?? 0,
            ProposalId = proposalHistoryDto.ProposalId,
            EventType = (EEventType)proposalHistoryDto.EventType,
            Description = proposalHistoryDto.Description
        }; 
    }
    public static ProposalHistoryDto ToDto(this ProposalHistory proposalHistory)
    {
        return new ProposalHistoryDto(
            proposalHistory.Id,
            proposalHistory.ProposalId,
            (int)proposalHistory.EventType,
            proposalHistory.Description
        );
    }
}
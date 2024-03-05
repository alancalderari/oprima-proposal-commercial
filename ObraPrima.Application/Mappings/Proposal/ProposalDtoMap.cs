using ObraPrima.Application.DTOs.Proposal;

namespace ObraPrima.Application.Mappings.Proposal;

public static class ProposalDtoMap
{
    public static Domain.Context.Entities.Proposal ToEntity(this ProposalDto proposalDto)
    {
        return new Domain.Context.Entities.Proposal
        {
            LeadId = proposalDto.LeadId,
            ProposalProduct = proposalDto.ProposalProduct.ToEntity(),
            ProposalHistories = proposalDto.ProposalHistories?.Select(x => x.ToEntity()).ToList()
        };
    }
    
    public static ProposalDto ToDto(this Domain.Context.Entities.Proposal proposal)
    {
        var proposalDto = new ProposalDto(
            proposal.Id,
            proposal.LeadId,
            proposal.ProposalProduct!.ToDto(),
            proposal.ProposalHistories?.Select(x => x.ToDto()).ToList()
        );
        
        return proposalDto;
    }
}
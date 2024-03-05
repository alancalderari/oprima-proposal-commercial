using ObraPrima.Application.DTOs.Proposal;

namespace ObraPrima.Application.Services.Contracts;

public interface IProposalService
{
    Task<ResultService> GetProposalAsync(int proposalId);
    Task<ResultService> PutUpdateProposalAsync(int proposalId, object proposal);
    Task<ResultService<ProposalDto>> PostCreateProposalAsync(ProposalDto proposal);
}
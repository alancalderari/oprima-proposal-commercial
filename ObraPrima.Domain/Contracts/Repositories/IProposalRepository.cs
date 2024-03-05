using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Domain.Contracts.Repositories;

public interface IProposalRepository
{
    Task<Proposal> GetProposalAsync(int proposalId);
    Task<Proposal> PutUpdateProposalAsync(int proposalId, Proposal proposal);
    Task<Proposal?> PostCreateProposalAsync(Proposal proposal);
}
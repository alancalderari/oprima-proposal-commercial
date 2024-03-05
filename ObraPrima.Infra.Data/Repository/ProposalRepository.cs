using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Contracts.Repositories;
using ObraPrima.Infra.Data.Data;

namespace ObraPrima.Infra.Data.Repository;

public class ProposalRepository(AppDbContext _context) : IProposalRepository
{
    public Task<Proposal> GetProposalAsync(int proposalId)
    {
        throw new NotImplementedException();
    }

    public Task<Proposal> PutUpdateProposalAsync(int proposalId, Proposal proposal)
    {
        throw new NotImplementedException();
    }

    public async Task<Proposal?> PostCreateProposalAsync(Proposal proposal)
    {
        await _context.Proposals.AddAsync(proposal);
        await _context.SaveChangesAsync();

        return proposal;
    }
}
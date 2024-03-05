using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Application.DTOs.Proposal.Validations;
using ObraPrima.Application.Mappings.Proposal;
using ObraPrima.Application.Services.Contracts;
using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Contracts.Repositories;

namespace ObraPrima.Application.Services;

public class ProposalService(IProposalRepository _repository) : IProposalService
{
    public async Task<ResultService> GetProposalAsync(int proposalId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService> PutUpdateProposalAsync(int proposalId, object proposal)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<ProposalDto>> PostCreateProposalAsync(ProposalDto? proposalDto)
    {
        if (proposalDto is null)
            return ResultService.Fail<ProposalDto>("Proposal is null");

        var result = await new ProposalDtoValidation().ValidateAsync(proposalDto);
        
        if (!result.IsValid)
            return ResultService.RequestError<ProposalDto>("Invalid property", result);

        var proposal = await _repository.PostCreateProposalAsync(proposalDto.ToEntity());

        if (proposal is null)
            return ResultService.Fail<ProposalDto>("Failed to create proposal");

        return ResultService.Ok(proposal.ToDto());
    }
}
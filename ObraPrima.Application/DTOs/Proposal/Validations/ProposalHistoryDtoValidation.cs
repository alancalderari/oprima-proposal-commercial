using FluentValidation;

namespace ObraPrima.Application.DTOs.Proposal.Validations;

public class ProposalHistoryDtoValidation : AbstractValidator<ProposalHistoryDto>
{
    public ProposalHistoryDtoValidation()
    {
        RuleFor(x => x.ProposalId)
            .NotNull()
            .WithMessage("Proposal id is required.");
        
        RuleFor(x => x.EventType)
            .NotNull()
            .WithMessage("Event type is required.");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Description is required.");
    }
}
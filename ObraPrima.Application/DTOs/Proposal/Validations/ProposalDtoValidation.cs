using FluentValidation;

namespace ObraPrima.Application.DTOs.Proposal.Validations;

public class ProposalDtoValidation : AbstractValidator<ProposalDto>
{
    public ProposalDtoValidation()
    {
        RuleFor(x => x.LeadId)
            .NotEmpty()
            .NotNull()
            .WithMessage("LeadId is required");
        
        RuleFor(x => x.ProposalProduct)
            .NotNull()
            .WithMessage("Proposal product is required")
            .SetValidator( new ProposalProductDtoValidation());
    }
}
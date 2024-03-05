using FluentValidation;

namespace ObraPrima.Application.DTOs.Proposal.Validations;

public class ProposalProductOptionalDtoValidation : AbstractValidator<ProposalProductOptionalDto>
{
    public ProposalProductOptionalDtoValidation()
    {
        RuleFor(x => x.PlanId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Plan id is required");
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .When(x => x.Price < 0)
            .NotNull()
            .WithMessage("Price is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Price must have 2 decimal places");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required");
        
        RuleFor(x => x.PriceDiscount)
            .NotEmpty()
            .When(x => x.PriceDiscount < 0)
            .NotNull()
            .WithMessage("Price discount is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Price discount must have 2 decimal places");
    }
}
using FluentValidation;

namespace ObraPrima.Application.DTOs.Proposal.Validations;

public class ProposalProductDtoValidation : AbstractValidator<ProposalProductDto>
{
    public ProposalProductDtoValidation()
    {
        RuleFor(x => x.PlanId)
            .NotEmpty()
            .NotNull()
            .WithMessage("PlanId is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Price is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Price must have 2 decimal places");
        
        RuleFor(x => x.PriceDiscount)
            .NotEmpty()
            .When(x => x.PriceDiscount < 0)
            .NotNull()
            .WithMessage("Price discount is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Price discount must have 2 decimal places");
        
        RuleFor(x => x.MembershipRate)
            .NotEmpty()
            .NotNull()
            .WithMessage("Membership rate is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Membership rate must have 2 decimal places");
        
        RuleFor(x => x.MembershipRateDiscount)
            .NotEmpty()
            .When(x => x.MembershipRateDiscount < 0)
            .NotNull()
            .WithMessage("Membership rate discount is required")
            .PrecisionScale(14,2, true)
            .WithMessage("Membership rate discount must have 2 decimal places");
        
        RuleFor(x => x.Period)
            .NotEmpty()
            .NotNull()
            .WithMessage("Period is required");

        RuleForEach(x => x.ProposalProductOptionals)
            .SetValidator(new ProposalProductOptionalDtoValidation());
    }
}
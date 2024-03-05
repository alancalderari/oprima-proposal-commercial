using FluentValidation;

namespace ObraPrima.Application.DTOs.User.Validations;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password is invalid");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage("E-mail is invalid");

    }
}
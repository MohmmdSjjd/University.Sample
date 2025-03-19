using FluentValidation;

namespace Application.Features.Commands.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not a valid email address")
            .MaximumLength(50).WithMessage("Email must not exceed 50 characters");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").Length(min: 6, max: 50).WithMessage("Password must be between 6 and 50 characters");
    }
}
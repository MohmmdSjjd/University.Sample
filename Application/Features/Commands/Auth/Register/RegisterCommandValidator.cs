using FluentValidation;

namespace Application.Features.Commands.Auth.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required").EmailAddress().WithMessage("{PropertyName} is not a valid email address").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters").MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters long");

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
    }
}
using FluentValidation;

namespace Application.Features.Commands.Course.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(min:3,max:50).WithMessage("Name must be between 3 and 50 characters");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(10).WithMessage("Code must be less than 10 characters");
    }
}
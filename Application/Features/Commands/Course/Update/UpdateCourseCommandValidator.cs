using FluentValidation;

namespace Application.Features.Commands.Course.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(min: 3, max: 50).WithMessage("Name must be between 3 and 50 characters");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(10).WithMessage("Code must be less than 10 characters");
    }
}
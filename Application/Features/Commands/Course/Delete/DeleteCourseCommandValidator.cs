using FluentValidation;

namespace Application.Features.Commands.Course.Delete;

public class CreateCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
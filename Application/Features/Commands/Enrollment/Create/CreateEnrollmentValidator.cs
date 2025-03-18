using FluentValidation;

namespace Application.Features.Commands.Enrollment.Create;

public class CreateEnrollmentValidator : AbstractValidator<CreateEnrollmentCommand>
{
    public CreateEnrollmentValidator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.CourseIds).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.Commands.Student.Delete;

public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required")
            .Must(c => true).WithMessage("Must be a valid Guid");
    }
}
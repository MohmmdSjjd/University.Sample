using FluentValidation;

namespace Application.Features.Commands.Student.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.NationalCode).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
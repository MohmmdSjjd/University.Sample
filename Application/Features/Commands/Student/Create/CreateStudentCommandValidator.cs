using FluentValidation;

namespace Application.Features.Commands.Student.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
            .Length(min:3,max:50).WithMessage("First Name must be between 3 and 50 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required")
            .Length(min: 3, max: 50).WithMessage("Last Name must be between 3 and 50 characters");
        RuleFor(x => x.NationalCode).NotEmpty().WithMessage("National Code is required")
            .Length(min: 10, max: 10).WithMessage("National Code must be 10 characters");
        RuleFor(x => x.BirtDate).NotEmpty().WithMessage("Birth Date is required")
            .LessThan(DateTime.Now).WithMessage("Birth Date must be less than current date");
    }
}
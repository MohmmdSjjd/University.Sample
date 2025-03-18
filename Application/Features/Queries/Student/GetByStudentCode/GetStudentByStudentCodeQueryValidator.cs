using FluentValidation;

namespace Application.Features.Queries.Student.GetByStudentCode;

public class GetStudentByStudentCodeQueryValidator : AbstractValidator<GetStudentByStudentCodeQuery>
{
    public GetStudentByStudentCodeQueryValidator()
    {
        RuleFor(x => x.StudentCode).NotEmpty().WithMessage("{PropertyName} is required");

    }
}
using FluentValidation;

namespace Application.Features.Queries.Student.GetByNationalCode;

public class GetStudentByNationalCodeQueryValidator : AbstractValidator<GetStudentByNationalCodeQuery>
{
    public GetStudentByNationalCodeQueryValidator()
    {
        RuleFor(x => x.NationalCode).NotEmpty().WithMessage("NationalCode is required").MinimumLength(10).MaximumLength(10);
    }
}
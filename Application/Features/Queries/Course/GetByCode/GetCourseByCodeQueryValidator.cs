using FluentValidation;

namespace Application.Features.Queries.Course.GetByCode;

public class GetCourseByCodeQueryValidator : AbstractValidator<GetCourseByCodeQuery>
{
    public GetCourseByCodeQueryValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .Length(min:1,max:10);
    }
}
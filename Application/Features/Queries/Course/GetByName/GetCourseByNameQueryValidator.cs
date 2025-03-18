using FluentValidation;

namespace Application.Features.Queries.Course.GetByName;

public class GetCourseByCodeQueryValidator : AbstractValidator<GetCourseByNameQuery>
{
    public GetCourseByCodeQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(min:3,max:50);
    }
}
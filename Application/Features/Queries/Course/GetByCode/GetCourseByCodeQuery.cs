using Application.Dtos.Course;
using MediatR;

namespace Application.Features.Queries.Course.GetByCode
{
    public record GetCourseByCodeQuery : IRequest<CourseResponseDto>
    {
        public string Code { get; set; }
    }
}

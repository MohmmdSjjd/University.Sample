using Application.Dtos.Course;
using MediatR;

namespace Application.Features.Queries.Course.GetByName
{
    public record GetCourseByNameQuery : IRequest<CourseDto>
    {
        public string Name { get; set; }
    }
}

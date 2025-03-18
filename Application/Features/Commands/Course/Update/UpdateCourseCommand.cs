using Application.Dtos.Course;
using MediatR;

namespace Application.Features.Commands.Course.Update
{
    public record UpdateCourseCommand : IRequest<CourseDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

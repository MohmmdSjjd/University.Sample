using Application.Dtos.Course;
using Application.Dtos.Course.Commands;
using MediatR;

namespace Application.Features.Commands.Course.Update
{
    public record UpdateCourseCommand : IRequest<UpdateCourseCommandResponseDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

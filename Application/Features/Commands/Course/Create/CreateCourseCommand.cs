using Application.Dtos.Course.Commands;
using MediatR;

namespace Application.Features.Commands.Course.Create
{
    public record CreateCourseCommand : IRequest<CreateCourseCommandResponseDto>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

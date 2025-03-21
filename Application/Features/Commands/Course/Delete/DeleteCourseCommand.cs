using Application.Dtos.Course.Commands;
using MediatR;

namespace Application.Features.Commands.Course.Delete
{
    public record DeleteCourseCommand : IRequest<DeleteCourseCommandResponseDto>
    {
        public Guid Id { get; init; }
    }
}

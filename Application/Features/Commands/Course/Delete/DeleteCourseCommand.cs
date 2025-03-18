using MediatR;

namespace Application.Features.Commands.Course.Delete
{
    public record DeleteCourseCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
    }
}

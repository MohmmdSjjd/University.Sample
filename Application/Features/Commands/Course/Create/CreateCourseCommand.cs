using MediatR;

namespace Application.Features.Commands.Course.Create
{
    public record CreateCourseCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

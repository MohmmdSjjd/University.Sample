using Application.Dtos;
using MediatR;

namespace Application.Features.Commands.Enrollment.Create
{
    public record CreateEnrollmentCommand : IRequest<List<EnrollmentsDto>>
    {
        public Guid StudentId { get; set; }
        public List<Guid> CourseIds { get; set; }
    }
}

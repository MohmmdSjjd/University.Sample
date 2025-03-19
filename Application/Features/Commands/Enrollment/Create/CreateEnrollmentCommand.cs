using Application.Dtos.Enrollment;
using MediatR;

namespace Application.Features.Commands.Enrollment.Create
{
    public record CreateEnrollmentCommand : IRequest<List<EnrollmentDto>>
    {
        public Guid StudentId { get; set; }
        public List<Guid> CourseIds { get; set; }
    }
}

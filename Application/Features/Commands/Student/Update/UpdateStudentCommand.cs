using Application.Dtos.Student;
using MediatR;

namespace Application.Features.Commands.Student.Update
{
    public record UpdateStudentCommand : IRequest<StudentDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

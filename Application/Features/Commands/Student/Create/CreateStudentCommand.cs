using Application.Dtos.Student;
using Application.Dtos.Student.Commands;
using MediatR;

namespace Application.Features.Commands.Student.Create
{
    public record CreateStudentCommand : IRequest<CreateStudentCommandResponseDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

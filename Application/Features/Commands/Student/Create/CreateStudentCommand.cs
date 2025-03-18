using Application.Dtos.Student;
using MediatR;

namespace Application.Features.Commands.Student.Create
{
    public record CreateStudentCommand:IRequest<StudentDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirtDate { get; set; }
    }
}

using Application.Dtos.Student;
using MediatR;

namespace Application.Features.Queries.Student.GetByStudentCode
{
    public class GetStudentByStudentCodeQuery : IRequest<StudentDto>
    {
        public Guid StudentCode { get; set; }
    }
}
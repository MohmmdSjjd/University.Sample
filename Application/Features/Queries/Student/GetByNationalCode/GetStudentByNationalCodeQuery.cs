using Application.Dtos.Student;
using MediatR;

namespace Application.Features.Queries.Student.GetByNationalCode
{
    public class GetStudentByNationalCodeQuery : IRequest<StudentDto>
    {
        public string NationalCode { get; set; }
    }
}

using Application.Dtos.Student;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Queries.Student.GetByStudentCode;

public class GetStudentByStudentCodeQueryHandler :StudentBase, IRequestHandler<GetStudentByStudentCodeQuery, StudentDto>
{
    public GetStudentByStudentCodeQueryHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<StudentDto> Handle(GetStudentByStudentCodeQuery request, CancellationToken cancellationToken)
    {
        var foundedStudent = await StudentRepository.GetByStudentCodeAsync(request.StudentCode);

        if (foundedStudent == null)
        {
            throw new ApiException("Student not found", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<StudentDto>(foundedStudent);
    }

}
using Application.Dtos.Student;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Queries.Student.GetByNationalCode;

public class GetStudentByNationalCodeQueryHandler : StudentBase, IRequestHandler<GetStudentByNationalCodeQuery, StudentDto>
{
    public GetStudentByNationalCodeQueryHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<StudentDto> Handle(GetStudentByNationalCodeQuery request, CancellationToken cancellationToken)
    {
        var foundedStudent = await StudentRepository.GetByNationalCodeAsync(request.NationalCode);

        if (foundedStudent == null)
        {
            throw new ApiException("Student not found", 404);
        }

        return Mapper.Map<StudentDto>(foundedStudent);
    }
}
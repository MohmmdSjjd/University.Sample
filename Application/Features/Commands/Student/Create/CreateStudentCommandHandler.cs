using System.Net;
using Application.Dtos.Student;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Student.Create;

public class CreateStudentCommandHandler : StudentBase,IRequestHandler<CreateStudentCommand, StudentDto>
{
    public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {


        var existingStudentByName = await StudentRepository.GetByNationalCodeAsync(request.NationalCode);

        if (existingStudentByName != null)
        {
            throw new ApiException("Student already exists", (int)HttpStatusCode.BadRequest);
        }

        var newStudent = await StudentRepository.AddAsync(Mapper.Map<Domain.Entities.Student>(request));

        if (newStudent == null)
        {
            throw new ApiException("Failed to create course", (int)HttpStatusCode.InternalServerError);
        }

        return Mapper.Map<StudentDto>(newStudent);

    }


}
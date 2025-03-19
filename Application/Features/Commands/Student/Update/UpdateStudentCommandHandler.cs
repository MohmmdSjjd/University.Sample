using Application.Dtos.Student;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Commands.Student.Update;

public class UpdateStudentCommandHandler : StudentBase, IRequestHandler<UpdateStudentCommand, StudentDto>
{
    public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var existingStudentByName = await StudentRepository.GetByNationalCodeAsync(request.NationalCode);

        if (existingStudentByName == null || existingStudentByName.Id == request.Id)
        {
            var student = await StudentRepository.UpdateAsync(Mapper.Map<Domain.Entities.Student>(request));

            if (student == null)
                throw new ApiException("Nothing Changed", (int)HttpStatusCode.NotFound);

            return Mapper.Map<StudentDto>(student);
        }
        throw new ApiException("Student already exists", (int)HttpStatusCode.BadRequest);
    }

}
using Application.Dtos.Student;
using Application.Dtos.Student.Commands;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Commands.Student.Update;

public class UpdateStudentCommandHandler : StudentBase, IRequestHandler<UpdateStudentCommand, UpdateStudentCommandResponseDto>
{
    public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<UpdateStudentCommandResponseDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var existingStudentByName = await StudentRepository.GetByNationalCodeAsync(request.NationalCode);

        if (existingStudentByName == null || existingStudentByName.Id == request.Id)
        {
            var student = await StudentRepository.UpdateAsync(Mapper.Map<Domain.Entities.Student>(request));

            if (student == null)
                throw new ApiException("Nothing Changed", (int)HttpStatusCode.NotFound);

            return Mapper.Map<UpdateStudentCommandResponseDto>(student);
        }
        throw new ApiException("Student already exists", (int)HttpStatusCode.BadRequest);
    }

}
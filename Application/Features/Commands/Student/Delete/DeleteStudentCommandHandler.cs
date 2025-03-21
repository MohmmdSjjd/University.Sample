using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;
using Application.Dtos.Student.Commands;

namespace Application.Features.Commands.Student.Delete;

public class DeleteStudentCommandHandler :StudentBase, IRequestHandler<DeleteStudentCommand, DeleteStudentCommandResponseDto>
{
    public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<DeleteStudentCommandResponseDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var deletedStudent = await StudentRepository.DeleteAsync(request.Id);

        if(!deletedStudent)
            throw new ApiException("Student not found", (int)HttpStatusCode.NotFound);

        return Mapper.Map<DeleteStudentCommandResponseDto>(deletedStudent);
    }

}
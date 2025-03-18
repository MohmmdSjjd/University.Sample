using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Student.Delete;

public class DeleteStudentCommandHandler :StudentBase, IRequestHandler<DeleteStudentCommand, bool>
{
    public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository, mapper)
    {
    }

    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var deletedStudent = await StudentRepository.DeleteAsync(request.Id);

        if(!deletedStudent)
            throw new ApiException("Student not found", 404);

        return deletedStudent;
    }

}
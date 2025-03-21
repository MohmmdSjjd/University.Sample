using System.Net;
using Application.Dtos.Course.Commands;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Course.Delete;

public class DeleteCourseCommandHandler :CourseBase, IRequestHandler<DeleteCourseCommand, DeleteCourseCommandResponseDto>
{
    public DeleteCourseCommandHandler(ICourseRepository courseRepository,IMapper mapper):base(courseRepository, mapper)
    {
    }
    public async Task<DeleteCourseCommandResponseDto> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {


        var deletedCourse = await CourseRepository.DeleteAsync(request.Id);

        if (!deletedCourse )
        {
            throw new ApiException(" Course not found", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<DeleteCourseCommandResponseDto>(deletedCourse);
    }
}
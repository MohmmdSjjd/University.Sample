using System.Net;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Course.Delete;

public class DeleteCourseCommandHandler :CourseBase, IRequestHandler<DeleteCourseCommand, bool>
{
    public DeleteCourseCommandHandler(ICourseRepository courseRepository,IMapper mapper):base(courseRepository, mapper)
    {
    }
    public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {


        var deletedCourse = await CourseRepository.DeleteAsync(request.Id);

        if (!deletedCourse )
        {
            throw new ApiException(" Course not found", (int)HttpStatusCode.NotFound);
        }

        return deletedCourse;
    }
}
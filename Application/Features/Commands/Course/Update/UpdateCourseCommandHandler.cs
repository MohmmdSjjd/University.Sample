using System.Net;
using Application.Dtos.Course;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Course.Update;

public class UpdateCourseCommandHandler : CourseBase, IRequestHandler<UpdateCourseCommand, CourseDto>
{

    public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {
    }

    public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {

        var updatedCourse = await CourseRepository.UpdateAsync(Mapper.Map<Domain.Entities.Course>(request));
          
        if (updatedCourse == null) {
            throw new ApiException("Course not found.", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<CourseDto>(updatedCourse);
    }
}
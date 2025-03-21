using System.Net;
using Application.Dtos.Course;
using Application.Dtos.Course.Commands;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Course.Update;

public class UpdateCourseCommandHandler : CourseBase, IRequestHandler<UpdateCourseCommand, UpdateCourseCommandResponseDto>
{

    public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {
    }

    public async Task<UpdateCourseCommandResponseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {

        var updatedCourse = await CourseRepository.UpdateAsync(Mapper.Map<Domain.Entities.Course>(request));
          
        if (updatedCourse == null) {
            throw new ApiException("Course not found.", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<UpdateCourseCommandResponseDto>(updatedCourse);
    }
}
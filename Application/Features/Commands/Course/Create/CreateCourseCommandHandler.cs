using System.Net;
using Application.Dtos.Course.Commands;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Course.Create;

public class CreateCourseCommandHandler : CourseBase, IRequestHandler<CreateCourseCommand, CreateCourseCommandResponseDto>
{


    public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {

    }
    public async Task<CreateCourseCommandResponseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {

        var existingCourseByName = await CourseRepository.GetByNameAsync(request.Name);
        var existingCourseByCode = await CourseRepository.GetByCodeAsync(request.Code);

        if (existingCourseByName != null || existingCourseByCode != null)
        {
            throw new ApiException("Course already exists", (int)HttpStatusCode.BadRequest);
        }

        var newCourse = await CourseRepository.AddAsync(Mapper.Map<Domain.Entities.Course>(request));

        if (newCourse == null)
        {
            throw new ApiException("Failed to create course", (int)HttpStatusCode.InternalServerError);
        }

        return  Mapper.Map<CreateCourseCommandResponseDto>(newCourse);
    }
}
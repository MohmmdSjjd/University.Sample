using Application.Dtos.Course;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Queries.Course.GetByCode;

public class GetCourseByCodeQueryHandler : CourseBase, IRequestHandler<GetCourseByCodeQuery, CourseResponseDto>
{
    public GetCourseByCodeQueryHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {
    }

    public async Task<CourseResponseDto> Handle(GetCourseByCodeQuery request, CancellationToken cancellationToken)
    {
        var foundedCourse =await CourseRepository.GetByCodeAsync(request.Code);

        if (foundedCourse == null)
        {
            throw new ApiException("Course not found", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<CourseResponseDto>(foundedCourse);

    }


}
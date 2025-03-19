using Application.Dtos.Course;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Queries.Course.GetByCode;

public class GetCourseByCodeQueryHandler : CourseBase, IRequestHandler<GetCourseByCodeQuery, CourseDto>
{
    public GetCourseByCodeQueryHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {
    }

    public async Task<CourseDto> Handle(GetCourseByCodeQuery request, CancellationToken cancellationToken)
    {
        var foundedCourse =await CourseRepository.GetByCodeAsync(request.Code);

        if (foundedCourse == null)
        {
            throw new ApiException("Course not found", (int)HttpStatusCode.NotFound);
        }

        return Mapper.Map<CourseDto>(foundedCourse);

    }


}
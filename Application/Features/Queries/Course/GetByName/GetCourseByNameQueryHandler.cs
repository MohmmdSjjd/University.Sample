using Application.Dtos.Course;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Queries.Course.GetByName;

public class GetCourseByNameQueryHandler : CourseBase, IRequestHandler<GetCourseByNameQuery, CourseDto>
{
    public GetCourseByNameQueryHandler(ICourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {
    }

    public async Task<CourseDto> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var foundedCourse =await CourseRepository.GetByNameAsync(request.Name);

        if (foundedCourse == null)
        {
            throw new ApiException("Course not found",404);
        }

        return Mapper.Map<CourseDto>(foundedCourse);

    }


}
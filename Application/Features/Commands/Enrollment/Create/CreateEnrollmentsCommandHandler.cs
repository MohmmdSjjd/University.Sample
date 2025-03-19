using Application.Dtos.Enrollment;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Net;

namespace Application.Features.Commands.Enrollment.Create;

public class CreateEnrollmentsCommandHandler : StudentCourseBase, IRequestHandler<CreateEnrollmentCommand, List<EnrollmentDto>>
{
    public CreateEnrollmentsCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository, IMapper mapper) : base(courseRepository, studentRepository, studentCourseRepository, mapper)
    {
    }


    public async Task<List<EnrollmentDto>> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var student = await StudentRepository.GetByIdAsync(request.StudentId);
        if (student == null)
        {
            throw new ApiException("Student not found", (int)HttpStatusCode.NotFound);
        }

        var courses = await CourseRepository.GetByIdsAsync(request.CourseIds);
        if (courses.Count != request.CourseIds.Count)
        {
            throw new ApiException("Some courses not found", (int)HttpStatusCode.NotFound);
        }

        var enrollments = new List<StudentCourse>();
        foreach (var courseId in request.CourseIds)
        {
            var enrollment = new StudentCourse()
            {
                StudentId = request.StudentId,
                CourseId = courseId,
            };
            enrollments.Add(enrollment);
        }

        var isAllCourseEnrollmentToStudent = await StudentCourseRepository.AddRangeAsync(enrollments);

        if (!isAllCourseEnrollmentToStudent)
        {
            throw new ApiException("Some courses not enrolled", (int)HttpStatusCode.BadRequest);
        }


        var enrollmentsDto = Mapper.Map<List<EnrollmentDto>>(enrollments);

        return enrollmentsDto;
    }

}
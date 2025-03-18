using Application.Dtos;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Commands.Enrollment.Create;

public class CreateEnrollmentsCommandHandler : StudentCourseBase, IRequestHandler<CreateEnrollmentCommand, List<EnrollmentsDto>>
{
    public CreateEnrollmentsCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository, IMapper mapper) : base(courseRepository, studentRepository, studentCourseRepository, mapper)
    {
    }


    public async Task<List<EnrollmentsDto>> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var student = await StudentRepository.GetByIdAsync(request.StudentId);
        if (student == null)
        {
            throw new ApiException("Student not found", 404);
        }

        var courses = await CourseRepository.GetByIdsAsync(request.CourseIds);
        if (courses.Count != request.CourseIds.Count)
        {
            throw new ApiException("Some courses not found", 404);
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
            throw new ApiException("Some courses not enrolled", 400);
        }


        var enrollmentsDto = Mapper.Map<List<EnrollmentsDto>>(enrollments);

        return enrollmentsDto;
    }

}
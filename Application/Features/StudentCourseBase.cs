using AutoMapper;
using Domain.Contracts.Repositories;

namespace Application.Features;

public class StudentCourseBase
{
    public ICourseRepository CourseRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public IStudentCourseRepository StudentCourseRepository { get; }
    public IMapper Mapper { get; }

    public StudentCourseBase(ICourseRepository courseRepository,IStudentRepository studentRepository,IStudentCourseRepository studentCourseRepository, IMapper mapper)
    {
        CourseRepository = courseRepository;
        StudentRepository = studentRepository;
        StudentCourseRepository = studentCourseRepository;
        Mapper = mapper;
    }
}
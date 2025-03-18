using Application.Dtos.Course;
using Application.Dtos.Student;
using Application.Features.Commands.Course.Create;
using Application.Features.Commands.Course.Delete;
using Application.Features.Commands.Course.Update;
using Application.Features.Commands.Student.Create;
using Application.Features.Commands.Student.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();


            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, DeleteCourseCommand>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();


            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();

        }
    }
}

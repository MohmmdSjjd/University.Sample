using Application.Dtos.Course;
using Application.Dtos.Enrollment;
using Application.Dtos.Student;
using Application.Features.Commands.Auth.Register;
using Application.Features.Commands.Course.Create;
using Application.Features.Commands.Course.Update;
using Application.Features.Commands.Student.Create;
using Application.Features.Commands.Student.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Dto




            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(x => x.StudentCourses)).ReverseMap();


            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(x => x.StudentCourses)).ReverseMap();


            CreateMap<StudentCourse, EnrollmentDto>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ReverseMap();

            CreateMap<StudentCourse, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Course.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Course.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(x => x.Course.Code))
                ;

            CreateMap<StudentCourse, StudentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Student.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.Student.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.Student.LastName))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(x => x.Student.NationalCode))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(x => x.Student.BirthDate))
                .ForMember(dest => dest.StudentCode, opt => opt.MapFrom(x => x.Student.StudentCode))
                ;

            #endregion

            #region Commands

            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();


            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();

            #endregion
        }
    }
}

using Application.Dtos.Auth.Commands;
using Application.Dtos.Course;
using Application.Dtos.Course.Commands;
using Application.Dtos.Enrollment;
using Application.Dtos.Student;
using Application.Dtos.Student.Commands;
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

            #region GeneralDto & QueryResponse


            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(x => x.StudentCourses)).ReverseMap();


            CreateMap<Course, CourseResponseDto>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(x => x.StudentCourses)).ReverseMap();


            CreateMap<StudentCourse, EnrollmentDto>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ReverseMap();

            CreateMap<StudentCourse, CourseResponseDto>()
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

            #region CommandsResponse

            CreateMap<string, LoginCommandResponseDto>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));

            CreateMap<string, RegisterCommandResponseDto>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));

            CreateMap<Course, CreateCourseCommandResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();


                    CreateMap<bool, DeleteCourseCommandResponseDto>()
                .ForMember(dest => dest.IsCourseDeleted, opt => opt.MapFrom(src => src));

            CreateMap<Course, UpdateCourseCommandResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentCourses))
                ;


            CreateMap<Student, CreateStudentCommandResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.NationalCode))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ReverseMap();

            CreateMap<bool, DeleteStudentCommandResponseDto>()
                .ForMember(dest => dest.IsStudentDeleted, opt => opt.MapFrom(src => src));

            CreateMap<Student, UpdateStudentCommandResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.NationalCode))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.StudentCourses))
                .ReverseMap();

            #endregion

            #region Commands

            CreateMap<Course, CreateCourseCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();


            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();

            #endregion
        }
    }
}

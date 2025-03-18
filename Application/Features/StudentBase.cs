using AutoMapper;
using Domain.Contracts.Repositories;

namespace Application.Features;

public class StudentBase
{
    public IStudentRepository StudentRepository { get; }
    public IMapper Mapper { get; }

    public StudentBase(IStudentRepository studentRepository, IMapper mapper)
    {
        StudentRepository = studentRepository;
        Mapper = mapper;
    }
}
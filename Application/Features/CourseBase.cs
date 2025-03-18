using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Repositories;

namespace Application.Features
{
    public class CourseBase
    {
        public ICourseRepository CourseRepository { get; }
        public IMapper Mapper { get; }

        public CourseBase(ICourseRepository courseRepository, IMapper mapper)
        {
            CourseRepository = courseRepository;
            Mapper = mapper;
        }
    }
}

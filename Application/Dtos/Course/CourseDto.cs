using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Student;

namespace Application.Dtos.Course
{
    public class CourseDto
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<StudentDto> Students { get; set; }
    }
}

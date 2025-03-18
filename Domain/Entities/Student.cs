using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }    
        public Guid StudentCode { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public Student()
        {
            Id = Guid.NewGuid();
            StudentCode = Guid.NewGuid();
        }

    }
}

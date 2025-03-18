using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IStudentCourseRepository
    {
        Task<StudentCourse> GetByIdAsync(Guid id);
        Task<List<StudentCourse>> GetAllAsync();
        Task AddAsync(StudentCourse studentCourse);
        Task<StudentCourse?> UpdateAsync(StudentCourse studentCourse);
        Task<bool> DeleteAsync(StudentCourse studentCourse);
        Task<bool> AddRangeAsync(List<StudentCourse> studentCourses);
    }
}

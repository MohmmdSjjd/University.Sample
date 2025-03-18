using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class StudentCourseRepository :BaseRepository, IStudentCourseRepository
    {
        public StudentCourseRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<StudentCourse> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentCourse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourse?> UpdateAsync(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddRangeAsync(List<StudentCourse> studentCourses)
        {
            await Context.StudentCourses.AddRangeAsync(studentCourses);
            var affectedRows = await Context.SaveChangesAsync();
            return affectedRows > 0;
        }

       
    }
}

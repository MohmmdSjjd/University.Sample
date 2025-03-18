using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseContext _context;

        public CourseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            var foundedCourse = await _context.Courses.FindAsync(id);

            if (foundedCourse == null)
            {
                return null;
            }
            return foundedCourse;
        }

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public Task<Course?> GetByCodeAsync(string code)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.Code.ToLower() == code.ToLower());
        }

        public async Task<IEnumerable<Course>> GetAllAsync(int page = 1, int count = 10)
        {
            return
                await _context.Courses
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Course> AddAsync(Course course)
        {
            var newCourse = await _context.Courses.AddAsync(course);

            if (newCourse.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return newCourse.Entity;
            }
            return null;
        }

        public async Task<Course?> UpdateAsync(Course course)
        {
            var foundedCourse = await _context.Courses.FindAsync(course.Id);

            if (foundedCourse == null)
            {
                return null;
            }

            foundedCourse.Name = course.Name;
            foundedCourse.Code = course.Code;

            var affectedRow = await _context.SaveChangesAsync();

            return affectedRow > 0 ? foundedCourse : null;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

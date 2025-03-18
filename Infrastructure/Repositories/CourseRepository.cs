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
    public class CourseRepository : BaseRepository,ICourseRepository
    {

        public CourseRepository(DatabaseContext context): base(context)
        {
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            var foundedCourse = await Context.Courses.FindAsync(id);

            if (foundedCourse == null)
            {
                return null;
            }
            return foundedCourse;
        }

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await Context.Courses.Include(x=>x.StudentCourses).ThenInclude(x=>x.Student).FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public Task<Course?> GetByCodeAsync(string code)
        {
            return Context.Courses.Include(x => x.StudentCourses).ThenInclude(x => x.Student).FirstOrDefaultAsync(c => c.Code.ToLower() == code.ToLower());
        }

        public async Task<IEnumerable<Course>> GetAllAsync(int page = 1, int count = 10)
        {
            return
                await Context.Courses
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Course> AddAsync(Course course)
        {
            var newCourse = await Context.Courses.AddAsync(course);

            if (newCourse.State == EntityState.Added)
            {
                await Context.SaveChangesAsync();
                return newCourse.Entity;
            }
            return null;
        }

        public async Task<Course?> UpdateAsync(Course course)
        {
            var foundedCourse = await Context.Courses.FindAsync(course.Id);

            if (foundedCourse == null)
            {
                return null;
            }

            foundedCourse.Name = course.Name;
            foundedCourse.Code = course.Code;

            var affectedRow = await Context.SaveChangesAsync();

            return affectedRow > 0 ? foundedCourse : null;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var course = await Context.Courses.FindAsync(id);
            if (course != null)
            {
                Context.Courses.Remove(course);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<Course>> GetByIdsAsync(List<Guid> requestCourseIds)
        {
            return await Context.Courses.Where(c => requestCourseIds.Contains(c.Id)).ToListAsync();
        }
    }
}

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
    public class StudentCourseRepository : BaseRepository, IStudentCourseRepository
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
            // Remove duplicates from the list
            studentCourses = await RemoveDuplicateStudentCoursesFromList(studentCourses);

            // If the list is empty, return true because there is nothing to add
            // , and we don't want to throw an exception
            if (studentCourses.Count == 0)
            {
                return true;
            }

            await Context.StudentCourses.AddRangeAsync(studentCourses);
            var affectedRows = await Context.SaveChangesAsync();
            return affectedRows > 0;
        }


        private async Task<List<StudentCourse>> RemoveDuplicateStudentCoursesFromList(List<StudentCourse> studentCourses)
        {
            var courses = studentCourses;

            var existingStudentCourses = await Context.StudentCourses
                .Where(sc => courses[0].StudentId == sc.StudentId)
                .ToListAsync();

            studentCourses = studentCourses
                .Where(sc => !existingStudentCourses.Any(esc => esc.StudentId == sc.StudentId && esc.CourseId == sc.CourseId))
                .ToList();

            return studentCourses;
        }

    }
}

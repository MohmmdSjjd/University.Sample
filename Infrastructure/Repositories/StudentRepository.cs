using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository,IStudentRepository
    {
        public StudentRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            var foundedStudent = await Context.Students.FindAsync(id);

            if (foundedStudent == null)
            {
                return null;
            }
            return foundedStudent;
        }

        public async Task<Student?> GetByStudentCodeAsync(Guid studentCode)
        {
           return await Context.Students.Include(x=>x.StudentCourses).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.StudentCode == studentCode);
        }

        public async Task<Student?> GetByNationalCodeAsync(string nationalCode)
        {
            return await Context.Students.Include(x => x.StudentCourses).ThenInclude(x=>x.Course).FirstOrDefaultAsync(x => x.NationalCode == nationalCode);
        }

        public async Task<IEnumerable<Student>> GetAllAsync(int page = 1, int count = 10)
        {
            return
                await Context.Students
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();
        }

        public async Task<Student> AddAsync(Student student)
        {
            var newStudent = await Context.Students.AddAsync(student);

            if (newStudent.State == EntityState.Added)
            {
                await Context.SaveChangesAsync();
                return newStudent.Entity;
            }
            return null;
        }

        public async Task<Student?> UpdateAsync(Student student)
        {

            var foundedStudent = await Context.Students.FindAsync(student.Id);

            if (foundedStudent == null)
            {
                return null;
            }

            foundedStudent.FirstName = student.FirstName;
            foundedStudent.LastName = student.LastName;
            foundedStudent.NationalCode = student.NationalCode;
            foundedStudent.BirthDate = student.BirthDate;

            var affectedRow = await Context.SaveChangesAsync();

            return affectedRow > 0 ? foundedStudent : null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await Context.Students.FindAsync(id);
            if (student != null)
            {
                Context.Students.Remove(student);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

  
    }
}

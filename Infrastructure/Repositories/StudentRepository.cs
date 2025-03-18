using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _context;

        public StudentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            var foundedStudent = await _context.Students.FindAsync(id);

            if (foundedStudent == null)
            {
                return null;
            }
            return foundedStudent;
        }

        public async Task<Student?> GetByStudentCodeAsync(Guid studentCode)
        {
            var foundedStudent = await _context.Students.FirstOrDefaultAsync(x => x.StudentCode == studentCode);

            if (foundedStudent == null)
            {
                return null;
            }
            return foundedStudent;
        }

        public async Task<Student?> GetByNationalCodeAsync(string nationalCode)
        {
            var foundedStudent = await _context.Students.FirstOrDefaultAsync(x => x.NationalCode == nationalCode);

            if (foundedStudent == null)
            {
                return null;
            }
            return foundedStudent;
        }




        public async Task<IEnumerable<Student>> GetAllAsync(int page = 1, int count = 10)
        {
            return
                await _context.Students
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();
        }

        public async Task<Student> AddAsync(Student student)
        {
            var newStudent = await _context.Students.AddAsync(student);

            if (newStudent.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return newStudent.Entity;
            }
            return null;
        }

        public async Task<Student?> UpdateAsync(Student student)
        {

            var foundedStudent = await _context.Students.FindAsync(student.Id);

            if (foundedStudent == null)
            {
                return null;
            }

            foundedStudent.FirstName = student.FirstName;
            foundedStudent.LastName = student.LastName;
            foundedStudent.NationalCode = student.NationalCode;
            foundedStudent.BirthDate = student.BirthDate;

            var affectedRow = await _context.SaveChangesAsync();

            return affectedRow > 0 ? foundedStudent : null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

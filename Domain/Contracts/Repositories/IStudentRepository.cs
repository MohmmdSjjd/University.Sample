using Domain.Entities;

namespace Domain.Contracts.Repositories;

public interface IStudentRepository
{
    Task<Student> GetByIdAsync(Guid id);
    Task<IEnumerable<Student>> GetAllAsync(int page = 1, int count = 10);
    Task<Student?> GetByStudentCodeAsync(Guid studentCode);
    Task<Student?> GetByNationalCodeAsync(string nationalCode);
    Task<Student> AddAsync(Student student);
    Task<Student?> UpdateAsync(Student student);
    Task<bool> DeleteAsync(Guid id);
}
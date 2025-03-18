using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(Guid id); 
        Task<Course?> GetByNameAsync(string name);
        Task<Course?> GetByCodeAsync(string code);
        Task<IEnumerable<Course>> GetAllAsync(int page = 1, int count=10);  
        Task<Course> AddAsync(Course course);   
        Task<Course?> UpdateAsync(Course course);
        Task<bool> DeleteAsync(Guid id);
        Task<ICollection<Course>> GetByIdsAsync(List<Guid> requestCourseIds);
    }
}

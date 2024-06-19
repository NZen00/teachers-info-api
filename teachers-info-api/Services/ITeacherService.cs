using System.Collections.Generic;
using System.Threading.Tasks;
using teachers_info_api.Models;

namespace teachers_info_api.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(int id, Teacher teacher);
        Task DeleteAsync(int id);
    }
}

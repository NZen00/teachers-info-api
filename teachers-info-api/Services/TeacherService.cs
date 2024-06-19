using System.Collections.Generic;
using System.Threading.Tasks;
using teachers_info_api.Models;
using teachers_info_api.Repositories;

namespace teachers_info_api.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _repository.AddAsync(teacher);
        }

        public async Task UpdateAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _repository.GetByIdAsync(id);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Age = teacher.Age;
                existingTeacher.Subject = teacher.Subject;

                await _repository.UpdateAsync(existingTeacher);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

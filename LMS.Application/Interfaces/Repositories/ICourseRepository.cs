using LMS.Domain.Entities;

namespace LMS.Application.Interfaces.Repositories;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(int id);

    Task<List<Course>> GetAllAsync();

    Task AddAsync(Course course);

    Task UpdateAsync(Course course);

    Task DeleteAsync(Course course);

    Task<bool> ExistsAsync(int id);
}

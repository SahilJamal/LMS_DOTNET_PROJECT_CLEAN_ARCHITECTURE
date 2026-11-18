using LMS.Application.Interfaces.Repositories;
using LMS.Domain.Entities;
using LMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Course course)
    {
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Courses
            .AnyAsync(c => c.Id == id);
    }
}

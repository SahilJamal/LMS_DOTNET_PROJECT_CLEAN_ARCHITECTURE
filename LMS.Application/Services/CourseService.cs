using LMS.Application.DTOs.Courses;
using LMS.Application.Interfaces.Repositories;
using LMS.Application.Interfaces.Services;
using LMS.Domain.Entities;

namespace LMS.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseResponseDto> CreateCourseAsync(
        CreateCourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            CreatedAt = DateTime.UtcNow
        };

        await _courseRepository.AddAsync(course);

        return MapToResponse(course);
    }

    public async Task<CourseResponseDto?> GetCourseByIdAsync(
        int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course == null)
        {
            return null;
        }

        return MapToResponse(course);
    }

    public async Task<List<CourseResponseDto>> GetAllCoursesAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return courses.Select(MapToResponse).ToList();
    }

    public async Task<CourseResponseDto?> UpdateCourseAsync(
        int id,
        UpdateCourseDto dto)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course == null)
        {
            return null;
        }

        course.Title = dto.Title;
        course.Description = dto.Description;
        course.Price = dto.Price;

        await _courseRepository.UpdateAsync(course);

        return MapToResponse(course);
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course == null)
        {
            return false;
        }

        await _courseRepository.DeleteAsync(course);

        return true;
    }

    private static CourseResponseDto MapToResponse(Course course)
    {
        return new CourseResponseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Price = course.Price,
            CreatedAt = course.CreatedAt
        };
    }
}

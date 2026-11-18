using LMS.Application.DTOs.Courses;

namespace LMS.Application.Interfaces.Services;

public interface ICourseService
{
    Task<CourseResponseDto> CreateCourseAsync(
        CreateCourseDto dto);

    Task<CourseResponseDto?> GetCourseByIdAsync(
        int id);

    Task<List<CourseResponseDto>> GetAllCoursesAsync();

    Task<CourseResponseDto?> UpdateCourseAsync(
        int id,
        UpdateCourseDto dto);

    Task<bool> DeleteCourseAsync(int id);
}

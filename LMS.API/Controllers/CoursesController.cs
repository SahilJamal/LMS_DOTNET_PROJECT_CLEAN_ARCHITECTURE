using LMS.Application.DTOs.Courses;
using LMS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(
        [FromBody] CreateCourseDto dto)
    {
        var result = await _courseService.CreateCourseAsync(dto);

        return CreatedAtAction(
            nameof(GetCourseById),
            new { id = result.Id },
            result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();

        return Ok(courses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);

        if (course == null)
        {
            return NotFound(new
            {
                message = "Course not found"
            });
        }

        return Ok(course);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCourse(
        int id,
        [FromBody] UpdateCourseDto dto)
    {
        var course = await _courseService.UpdateCourseAsync(id, dto);

        if (course == null)
        {
            return NotFound(new
            {
                message = "Course not found"
            });
        }

        return Ok(course);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var deleted = await _courseService.DeleteCourseAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Course not found"
            });
        }

        return Ok(new
        {
            message = "Course deleted successfully"
        });
    }
}

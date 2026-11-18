using System.ComponentModel.DataAnnotations;

namespace LMS.Application.DTOs.Courses;

public class UpdateCourseDto
{
    [Required]
    [StringLength(150, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 1000000)]
    public decimal Price { get; set; }
}

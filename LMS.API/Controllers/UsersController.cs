using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    [HttpGet("me")]
    public IActionResult GetMyProfile()
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier
        );

        var email = User.FindFirstValue(
            ClaimTypes.Email
        );

        var role = User.FindFirstValue(
            ClaimTypes.Role
        );

        var name = User.FindFirstValue(
            ClaimTypes.Name
        );

        return Ok(new
        {
            userId,
            name,
            email,
            role
        });
    }
}

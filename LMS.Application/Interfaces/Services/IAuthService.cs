using LMS.Application.DTOs.Auth;

namespace LMS.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);

    Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
}

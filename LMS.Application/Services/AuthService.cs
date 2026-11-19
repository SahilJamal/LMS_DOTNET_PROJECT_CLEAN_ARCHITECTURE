using LMS.Application.DTOs.Auth;
using LMS.Application.Interfaces.Repositories;
using LMS.Application.Interfaces.Services;
using LMS.Domain.Entities;
using LMS.Domain.Enums;

namespace LMS.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordService passwordService,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(
        RegisterRequestDto dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var exists = await _userRepository.EmailExistsAsync(email);

        if (exists)
        {
            throw new InvalidOperationException(
                "Email is already registered."
            );
        }

        var user = new User
        {
            FullName = dto.FullName.Trim(),
            Email = email,
            Role = UserRole.Student,
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        user.PasswordHash = _passwordService.HashPassword(
            user,
            dto.Password
        );

        await _userRepository.AddAsync(user);

        return CreateAuthResponse(user);
    }

    public async Task<AuthResponseDto?> LoginAsync(
        LoginRequestDto dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null || !user.Active)
        {
            return null;
        }

        var validPassword = _passwordService.VerifyPassword(
            user,
            dto.Password
        );

        if (!validPassword)
        {
            return null;
        }

        return CreateAuthResponse(user);
    }

    private AuthResponseDto CreateAuthResponse(User user)
    {
        var tokenData = _jwtTokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = tokenData.Token,
            ExpiresAt = tokenData.ExpiresAt,
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }
}

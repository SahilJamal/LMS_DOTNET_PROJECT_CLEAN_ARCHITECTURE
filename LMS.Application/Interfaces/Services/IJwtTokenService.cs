using LMS.Domain.Entities;

namespace LMS.Application.Interfaces.Services;

public interface IJwtTokenService
{
    (string Token, DateTime ExpiresAt) GenerateToken(User user);
}

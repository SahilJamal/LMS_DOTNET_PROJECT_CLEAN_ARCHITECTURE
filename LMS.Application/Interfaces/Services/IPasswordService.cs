using LMS.Domain.Entities;

namespace LMS.Application.Interfaces.Services;

public interface IPasswordService
{
    string HashPassword(User user, string password);

    bool VerifyPassword(User user, string password);
}

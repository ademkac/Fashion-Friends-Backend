using Fashion_Friends_Backend.Models;

namespace Fashion_Friends_Backend.Services.Abstraction
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthData GetAuthData(int id);
    }
}

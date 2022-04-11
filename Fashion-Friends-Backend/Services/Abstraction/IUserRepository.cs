using Fashion_Friends_Backend.Models;

namespace Fashion_Friends_Backend.Services.Abstraction
{
    public interface IUserRepository : IEntityBaseRepository<UserRegister>
    {
        bool isEmailUniq(string email);
    };
}

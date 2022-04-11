using Fashion_Friends_Backend.Models;
using Fashion_Friends_Backend.Services.Abstraction;

namespace Fashion_Friends_Backend.Services
{
    public class UserRepository : EntityBaseRepository<UserRegister>, IUserRepository
    {
        public UserRepository(DataContext context): base (context)
        {

        }

        public bool isEmailUniq(string email)
        {

            var user = this.GetSingle(u => u.Email == email);
            return user == null;
        }
    }
}

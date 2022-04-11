using Fashion_Friends_Backend.Services.Abstraction;

namespace Fashion_Friends_Backend.Models
{
    public class UserRegister : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Newsletter { get; set; } = string.Empty;
    }
}

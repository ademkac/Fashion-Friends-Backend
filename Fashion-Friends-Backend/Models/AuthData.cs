namespace Fashion_Friends_Backend.Models
{
    public class AuthData
    {
        public string Token { get; set; } = string.Empty;
        public long TokenExpirationTime { get; set; }
        public int Id { get; set; }
    }
}

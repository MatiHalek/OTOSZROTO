namespace api.Models
{
    public class UserToken
    {
        public int UserTokenID { get; set; }
        public string? Token { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } = null!;
    }
}

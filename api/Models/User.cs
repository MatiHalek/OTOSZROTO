using System.Text.Json.Serialization;

namespace api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Access { get; set; }
        public ICollection<UserToken> Tokens { get; set; } = new List<UserToken>();
    }
}

using api.Models;

namespace api.Interfaces
{
    public interface IUserTokenRepository
    {
        UserToken Create(UserToken userToken);
        User Update(string token, string password);
    }
}

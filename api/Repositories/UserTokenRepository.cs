using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly AppDbContext context;
        public UserTokenRepository(AppDbContext context)
        {
            this.context = context;
        }
        public UserToken Create(UserToken userToken)
        {
            context.UserTokens.Add(userToken);
            context.SaveChanges();
            return userToken;
        }

        public User Update(string token, string password)
        {
            UserToken userToken = context.UserTokens.Where(ut => ut.Token == token).FirstOrDefault()!;
            if (userToken == null) return null!;

            User user_db = context.Users.Find(userToken.UserID)!;
            user_db.Password = BCrypt.Net.BCrypt.HashPassword(password);
            context.Users.Update(user_db);
            context.UserTokens.Remove(userToken);
            context.SaveChanges();
            return user_db;
        }
    }
}

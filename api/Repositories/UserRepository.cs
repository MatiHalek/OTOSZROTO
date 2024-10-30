using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User Create(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Creating new user failed: {ex.Message}");
            }
        }

        public User Get(int userID)
        {
            User user = context.Users.Find(userID)!;
            if (user == null)
            {
                throw new Exception($"Failed to fetch user with userID = {userID}");
            }
            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = context.Users.ToList();
            if (users.Count > 0) return users;
            return new List<User>();
        }

        public int Remove(int userID)
        {
            User user = context.Users.Find(userID)!;
            if (user == null) throw new Exception($"Failed to delete user with id = {userID}");
            try
            {
                context.Users.Remove(user);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user: {ex.Message}");
            }
        }

        public User GetByEmail(string email)
        {
            User user = context.Users.Where(u => u.Email == email).FirstOrDefault()!;
            if (user == null)
            {
                throw new Exception($"Failed to fetch user with email = {email}");
            }
            return user;
        }

        public User Update(User user,int userID)
        {
            User user_db = context.Users.Find(userID)!;
            if (user_db == null)
            {
                throw new Exception($"Failed to update user with user id = {userID}");
            }

            user_db.Name = user.Name;
            user_db.Surname = user.Surname;
            user_db.Email = user.Email;
            user_db.PhoneNumber = user.PhoneNumber;

            try
            {
                context.Users.Update(user_db);
                context.SaveChanges();
                return user_db;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user: {ex.Message}");
            }
        }
    }
}

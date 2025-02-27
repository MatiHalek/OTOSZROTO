﻿using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user); 
        User Update(User user,int userID); 
        User Get(int userID); 
        List<User> GetAll(); 
        int Remove(int userID);
        User GetByEmail(string email);
    }
}

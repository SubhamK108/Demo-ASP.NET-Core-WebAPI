using DemoWebAPI.Models;
using System.Collections.Generic;

namespace DemoWebAPI.Data
{
    public interface IUserDataProvider
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        User GetUser(string key);
        void DeleteUser(string key);
    }
}
using DemoWebAPI.Models;
using System.Collections.Generic;

namespace DemoWebAPI.Data
{
    public interface IDataProvider
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        User GetUser(int id);
        void DeleteUser(int id);
    }
}
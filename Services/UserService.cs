using System.Collections.Generic;
using System.Linq;
using DemoWebAPI.Models;

namespace DemoWebAPI.Services
{
    public class UserService
    {
        private readonly PostgreSqlContext _db;

        public UserService(PostgreSqlContext db) => _db = db;

        public List<User> GetAllUsers() => _db.UserList.ToList();

        public void AddUser(User user)
        {
            _db.UserList.Add(user);
            _db.SaveChanges();
        }

        public User GetUser(string key) => 
            _db.UserList.FirstOrDefault(x => (x.Email == key || x.Username == key));

        public void UpdateUser(User existingUser, User updatedUser)
        {
            existingUser.Name = updatedUser.Name;
            existingUser.Username = updatedUser.Username;
            existingUser.Password = updatedUser.Password;
            _db.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _db.UserList.Remove(user);
            _db.SaveChanges();
        }
    }
}
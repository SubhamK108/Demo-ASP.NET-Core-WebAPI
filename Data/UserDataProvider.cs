using DemoWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoWebAPI.Data
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly PostgreSqlContext _context;

        public UserDataProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.UserList.ToList();
        }

        public void AddUser(User user)
        {
            _context.UserList.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string key)
        {
            return _context.UserList.FirstOrDefault(x => (x.Username == key || x.Email == key));
        }

        public void DeleteUser(string key)
        {
            User user = _context.UserList.FirstOrDefault(x => (x.Username == key || x.Email == key));
            _context.UserList.Remove(user);
            _context.SaveChanges();
        }
    }
}
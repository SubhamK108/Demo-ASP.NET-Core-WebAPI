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
            return _context.UsersList.ToList();
        }

        public void AddUser(User user)
        {
            _context.UsersList.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.UsersList.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteUser(int id)
        {
            User user = _context.UsersList.FirstOrDefault(x => x.Id == id);
            _context.UsersList.Remove(user);
            _context.SaveChanges();
        }
    }
}
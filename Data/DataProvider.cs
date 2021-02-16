using DemoWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoWebAPI.Data
{
    public class DataProvider : IDataProvider
    {
        private readonly PostgreSqlContext _context;

        public DataProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
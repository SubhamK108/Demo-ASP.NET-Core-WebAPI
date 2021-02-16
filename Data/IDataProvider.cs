using DemoWebAPI.Models;
using System.Collections.Generic;

namespace DemoWebAPI.Data
{
    public interface IDataProvider
    {
        List<User> GetAllUsers();
    }
}
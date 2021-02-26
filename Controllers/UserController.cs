using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoWebAPI.Models;
using DemoWebAPI.Data;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDataProvider _userDataProvider;

        public UserController(IUserDataProvider userDataProvider)
        {
            _userDataProvider = userDataProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userDataProvider.GetAllUsers();
        }

        [HttpPost("[action]")]
        public IActionResult AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                _userDataProvider.AddUser(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("[action]/{key}")]
        public IActionResult DeleteUser(string key)
        {
            User user = _userDataProvider.GetUser(key);

            if (user == null)
            {
                return NotFound();
            }

            _userDataProvider.DeleteUser(key);
            return Ok();
        }
    }
}

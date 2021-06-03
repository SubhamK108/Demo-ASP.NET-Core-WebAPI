using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoWebAPI.Models;
using DemoWebAPI.Services;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _user;

        public UserController(UserService user) => _user = user;

        [HttpGet]
        public ActionResult<List<User>> Get() => _user.GetAllUsers();

        [HttpPost("[action]")]
        public ActionResult AddUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _user.AddUser(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("[action]/{key}")]
        public ActionResult<User> GetUser(string key)
        {
            User user = _user.GetUser(key);
            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("[action]/{key}")]
        public ActionResult UpdateUser(string key, [FromBody] User user)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }

            User existingUser = _user.GetUser(key);
            if (existingUser is null)
            {
                return NotFound();
            }

            _user.UpdateUser(existingUser, user);
            return Ok();
        }

        [HttpDelete("[action]/{key}")]
        public ActionResult DeleteUser(string key)
        {
            User user = _user.GetUser(key);
            if (user is null)
            {
                return NotFound();
            }

            _user.DeleteUser(user);
            return Ok();
        }

        [HttpGet("[action]/{key}")]
        public ActionResult<bool> CheckForUser(string key)
        {
            User user = _user.GetUser(key);
            return (user is null ? false : true);
        }
    }
}

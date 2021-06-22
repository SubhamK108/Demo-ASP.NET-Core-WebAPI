using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
                return Ok("User successfully added.");
            }

            return BadRequest("Invalid user credentials!");
        }

        [HttpGet("[action]/{key}")]
        public ActionResult<User> GetUser(string key)
        {
            User user = _user.GetUser(key);
            if (user is null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);
        }

        [HttpPut("[action]/{key}")]
        public ActionResult UpdateUser(string key, [FromBody] User user)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest("Invalid user credentials!");
            }

            User existingUser = _user.GetUser(key);
            if (existingUser is null)
            {
                return NotFound("User not found!");
            }

            _user.UpdateUser(existingUser, user);
            return Ok("User successfully updated.");
        }

        [HttpDelete("[action]/{key}")]
        public ActionResult DeleteUser(string key)
        {
            User user = _user.GetUser(key);
            if (user is null)
            {
                return NotFound("User not found!");
            }

            _user.DeleteUser(user);
            return Ok("User successfully deleted.");
        }

        [HttpGet("[action]/{key}")]
        public ActionResult<bool> CheckForUser(string key)
        {
            User user = _user.GetUser(key);
            return Ok(user is null ? false : true);
        }
    }
}

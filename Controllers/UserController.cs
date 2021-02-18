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
        private readonly IDataProvider _dataProvider;

        public UserController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataProvider.GetAllUsers();
        }

        [HttpPost("[action]")]
        public IActionResult AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                _dataProvider.AddUser(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("[action]/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _dataProvider.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            _dataProvider.DeleteUser(id);
            return Ok();
        }
    }
}

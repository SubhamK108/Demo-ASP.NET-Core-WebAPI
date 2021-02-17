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
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        public IActionResult AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                _dataProvider.AddUser(user);
                return Ok();
            }

            return BadRequest();
        }
    }
}
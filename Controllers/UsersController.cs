using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Livemodo_db.Services;
using Livemodo_db.Models;

namespace Livemodo_db.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/users
        [HttpGet]
        [EnableCors("AllowOrigin")]

        public ActionResult<List<User>> Get() =>
            _userService.GetAllUsers();

        // GET: api/users/{id}
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> GetUserById(string id)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }
        

        // POST: api/users
        [HttpPost]
        public ActionResult<User> RegisterUser(User user)
        {
            _userService.RegisterUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }
       

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, User userInDB)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            _userService.UpdateUser(id, userInDB);
            return NoContent();
        }
        
        // DELETE: api/user/{id}
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteUser(string id)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(user.Id);
            return NoContent();


        }
        
    }
}

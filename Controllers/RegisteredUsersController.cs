using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livemodo_db.Models;
using Livemodo_db.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livemodo_db.Controllers
{
    [Route("api/registered-users")]
    [ApiController]
    public class RegisteredUsersController : ControllerBase
    {
        private readonly RegisteredUserService _registeredUserService;

        public RegisteredUsersController(RegisteredUserService registeredUserService)
        {
            _registeredUserService = registeredUserService;
        }
        [HttpGet]
        [EnableCors("AllowOrigin")]

        public ActionResult<List<RegisteredUser>> GetAllUsers() =>
            _registeredUserService.GetAllRegisteredUsers();

        [HttpGet("{id:length(24)}", Name = "GetRegisteredUser")]
        public ActionResult<RegisteredUser> GetRegisteredUserById(string id)
        {
            var user = _registeredUserService.GetRegisteredUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        //Post api/registered-users/

        [HttpPost]
        [EnableCors("AllowAllHeaders")]
        public ActionResult<RegisteredUser> PostRegisteredUser(string id, RegisteredUser user)
        {
            _registeredUserService.PostUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }
        //Put api/registered-users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateExistingUser(string id, RegisteredUser userInDB)
        {
            var user = _registeredUserService.GetRegisteredUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _registeredUserService.UpdateExistingUser(id, userInDB);
            return NoContent();
        }
        //Delete api/registered-user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = _registeredUserService.GetRegisteredUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _registeredUserService.DeleteExistingUser(user.Id);
            return NoContent();

        }
    }
}
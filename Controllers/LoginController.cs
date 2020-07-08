//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Livemodo_db.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;

//namespace Livemodo_db.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [EnableCors("AllowAllHeaders")]
 
//    public class LoginController : ControllerBase
//    {
//        private IConfiguration _config;
//        public LoginController(IConfiguration config)
//        {
//            _config = config;
//        }
//        public IActionResult Login(string username, string password)
//        {
//            User login = new User
//            {
//                Username = username,
//                Password = password
//            };
//            IActionResult response = Unauthorized();

//            var user = AuthenticateUser(login);
//            if(user != null)
//            {
//                var tokenStr = GenerateJSONWebToken(user);
//                response = Ok(new { token = tokenStr });
//            }
//            return response;

//        }
//        //remove [fromBody] if throws error
//        private User AuthenticateUser(User login)
//        {

//            User user = null;

//            if (login.Username == "TheDude" && login.Password == "123")
//                //if (login.Username == user.Username)
//            {
//                user = new User { Username = "TheDude", Email = "TheDude123@email.com", Password = "123" };
//            }
//            return user;
//        }

//        private string GenerateJSONWebToken(User userinfo)
//        {
//            var algorithm = SecurityAlgorithms.HmacSha256;
//            var secretBytes = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
//            var securityKey = new SymmetricSecurityKey(secretBytes);
//            var credentials = new SigningCredentials(securityKey, algorithm);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub,userinfo.Username),
//                new Claim(JwtRegisteredClaimNames.Email,userinfo.Email),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var token = new JwtSecurityToken(
//                issuer: _config["Jwt:Issuer"],
//                audience: _config["jwt:Issuer"],
//                claims,
//                expires: DateTime.Now.AddMinutes(120),
//                signingCredentials: credentials                 
//                );

//            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
//            return encodeToken;
//        }
//        [Authorize]
//        [HttpPost("Post")]
//        [EnableCors("AllowAllHeaders")]
//        public string Post()
//        {
//            var identity = HttpContext.User.Identity as ClaimsIdentity;
//            IList<Claim> claim = identity.Claims.ToList();
//            var userName = claim[0].Value;
//            return "Welcome, " + userName;
//        }
//        [HttpGet("GetValue")]

//        public ActionResult<IEnumerable<string>> Get()
//        {
//            return new string[] { "Value1", "Value2", "Value3" };
//        }

//    }
//}
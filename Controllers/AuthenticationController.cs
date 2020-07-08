using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cors;

namespace Livemodo_db.Controllers
{

    [Route("api/authenticate")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Authenticate()
        {

            var claims = new[]
          {
                new Claim(JwtRegisteredClaimNames.Sub, "Bob"),
                new Claim(JwtRegisteredClaimNames.Email,"Email@gmail.com"),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var algorithm = SecurityAlgorithms.HmacSha256;
            var secretBytes = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(secretBytes);
            var credentials = new SigningCredentials(securityKey, algorithm);


            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            var access_token = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { access_token});

        }
    }
}
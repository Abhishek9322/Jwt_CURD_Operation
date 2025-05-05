using Jwt_CURD_Operation.ModelClasses;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Jwt_CURD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
         
        }

        //we creating A jwt token request

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            if (user.UserName == "Abhishek" && user.Password == "Abhi@1234")
            {
                //Add custom calim
                var Claims = new[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("UserType","Admin"),  //  custom claims
                    new Claim("Email","abhi322@gmail.com"),
                    new Claim("department","IT"),
                    new Claim("Address","pune"),
                    // new Claim("imgcat2Url","C:\\Users\\Abhishek kamble\\Desktop\\cat2.PNG")
                };


                //var claims = new[] { new Claim(ClaimTypes.Name, user.UserName) };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
                var card = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: _config["Jwt:Issuer"],
                    audience: "https://localhost:7181",
                     claims: Claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: card

                );

                //it return the generated jwt token to the client after successful login  
                return Ok(
                    new 
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expires=token.ValidTo      //token time start from 

                    });  //give responce 200 ok  
            }
            return Unauthorized(); //return the responce 401 unauthorized if user name or password worng 

        }


    }

    public class UserLogin
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        //public byte[] ProfileImageUrl {  get; set; }  //store image as a byte

    }
}

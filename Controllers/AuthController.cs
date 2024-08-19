using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
<<<<<<< HEAD
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin login)
    {
         if (login.Username == "testuser" && login.Password == "password123")
        {
            var token = GenerateJwtToken();
            return Ok(new { token });
=======
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly string _key = "YourStrongSecretKey12345"; // Use a strong secret key

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "test" && model.Password == "password")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "yourIssuer",
                Audience = "yourAudience",
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
>>>>>>> main
        }

        return Unauthorized();
    }
<<<<<<< HEAD

    private string GenerateJwtToken()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}
=======
}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using webapi.Models;

//[Route("api/[controller]")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly string _key = "YourSecretKeyHere"; // Use a strong secret key

//    [HttpPost("login")]
//    public IActionResult Login([FromBody] LoginModel model)
//    {
//        if (model.Username == "test" && model.Password == "password")
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//           // var key = Encoding.ASCII.GetBytes("yourSecretKey");
//           // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourStrongSecretKey12345"));
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.Name, model.Username)
//                }),
//                Expires = DateTime.UtcNow.AddHours(1),
//                Issuer = "yourIssuer",
//                Audience = "yourAudience",
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            var tokenString = tokenHandler.WriteToken(token);

//            return Ok(new { Token = tokenString });
//        }

//        return Unauthorized();
//    }
//}
>>>>>>> main

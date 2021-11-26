using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TopChoiceHardware.Products.Domain.DTOs;

namespace TopChoiceHardware.ProductsService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserLogin(LoginDto user)
        {
            var usuario = user;
            if (usuario!=null)
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                //claims.AddClaim(new Claim("Email", usuario.Email));
                claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    // Nuestro token va a durar un día
                    Expires = DateTime.UtcNow.AddDays(1),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                var token = tokenHandler.WriteToken(createdToken);

                LoginResponseDto response = new LoginResponseDto
                {
                    Status = "Success",
                    Token = token
                };

                return new JsonResult(response) { StatusCode = 201 };
            }
            LoginResponseDto errorResponse = new LoginResponseDto
            {
                Status = "Error",
                Token = "The token could not be generated"
            };

            return new JsonResult(errorResponse) { StatusCode = 404 };
        }

    }
}

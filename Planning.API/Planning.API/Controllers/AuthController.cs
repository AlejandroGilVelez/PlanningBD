using Framework.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Planning.DataModel.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Planning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginInformation)
        {
            var userSeleccionado = await userRepository.ObtenerPorEmail(loginInformation.Email);

            if (userSeleccionado == null)
            {
                return Unauthorized();
            }            

            if (!Utilidades.Utils.VerifyPasswordHash(loginInformation.Password, userSeleccionado.PasswordHash, userSeleccionado.PasswordSalt))
            {
                return Unauthorized();
            }
                       
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userSeleccionado.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{userSeleccionado.Nombres} {userSeleccionado.Apellidos}")
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Miclavedecontraseña"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });


        }
    }
}
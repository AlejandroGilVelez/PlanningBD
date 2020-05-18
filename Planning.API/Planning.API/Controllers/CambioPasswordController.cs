using Framework.Dtos;
using Framework.Models;
using Framework.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Planning.API.Utilidades;
using Planning.DataModel.Repositories;
using System;
using System.Threading.Tasks;

namespace Planning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambioPasswordController : ControllerBase
    {
        #region Atributos

        private readonly ICambioPasswordRepository cambioPasswordRepository;
        private readonly IUserRepository userRepository;

        #endregion

        #region Constructor

        public CambioPasswordController(ICambioPasswordRepository cambioPasswordRepository, IUserRepository userRepository)
        {
            this.cambioPasswordRepository = cambioPasswordRepository;
            this.userRepository = userRepository;
        }

        #endregion

        #region Acciones

        [HttpPost("ExpiracionId")]
        public async Task<bool> ExpiracionId([FromBody]CambioPasswordDto cambioPasswordDto)
        {
            //1. Buscar el usuario.
            //2. Validar Id expiración.            

            var validarId = await cambioPasswordRepository.Find(x => x.Id == cambioPasswordDto.Id && x.Activo, x=> x.Usuario);

            if (validarId == null)
            {
                return false;
            }

            TimeSpan span = DateTime.Now - validarId.FechaCreacion;            

            if (validarId.MinutosExpiracion < span.TotalMinutes)
            {
                // Activo = false.
                validarId.Activo = false;
                await cambioPasswordRepository.Edit(validarId);
                //Enviar nuevo correo.         
                SendEmailUtils.SendEmail(validarId.Usuario.Correo, $"({validarId.Usuario.Nombres} {validarId.Usuario.Apellidos})", validarId.Id.ToString());
                return false;                
            }           
                     
            
            return true;
        }

        [HttpPost("RestaurarPassword")]
        public async Task<IActionResult> RestaurarPassword([FromBody]CambioPasswordDto cambioPasswordDto)
        {
            //1. Buscar el usuario.
            //2. Cambiiar el Password en la tabla usuario.            

            var validarId = await cambioPasswordRepository.Find(x => x.Id == cambioPasswordDto.Id && x.Activo, x=> x.Usuario);

            if (validarId == null)
            {
                return BadRequest("No existe el usuario");
            }

            byte[] passwordHash, passwordSalt;

            Utils.CreatePasswordHash(cambioPasswordDto.NuevoPassword, out passwordHash, out passwordSalt);
      
            validarId.Usuario.PasswordHash = passwordHash;
            validarId.Usuario.PasswordSalt = passwordSalt;
            validarId.Usuario.CambioPassword = true;

            await userRepository.Edit(validarId.Usuario);

            validarId.Activo = false;
            await cambioPasswordRepository.Edit(validarId);

            //false activo en tabla cambiopassword

            return Ok();
        }


        #endregion
    }
}
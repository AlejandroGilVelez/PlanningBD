using Framework.Dtos;
using Framework.Models;
using Framework.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planning.API.Utilidades;
using Planning.DataModel.Repositories;
using System;
using System.Threading.Tasks;

namespace Planning.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Atributos

        private readonly IUserRepository userRepository;
        private readonly ICambioPasswordRepository cambioPasswordRepository;

        #endregion

        #region Constructor

        public UserController(IUserRepository userRepository, ICambioPasswordRepository cambioPasswordRepository)
        {
            this.userRepository = userRepository;
            this.cambioPasswordRepository = cambioPasswordRepository;
        }

        #endregion

        #region Acciones


        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            //Thread.Sleep(3000); Se retraza la respuesta
            var result = await userRepository.GetAll();
            return Ok(result);

        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            var result = await userRepository.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await userRepository.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            await userRepository.Delete(result);


            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]UserDto user)
        {

            var validar = await userRepository.Find(x => x.Correo == user.Correo);

            if (validar != null)
            {
                return BadRequest("El correo ya existe");
            }

            user.Password = user.NroIdentificacion.ToString();

            byte[] passwordHash, passwordSalt;

            Utils.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            var usuario = new User
            {
                Id = Guid.NewGuid(),
                NroIdentificacion = user.NroIdentificacion,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Correo = user.Correo,
                Telefono = user.Telefono,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Activo = user.Activo,
                CambioPassword = false

            };

            usuario = await userRepository.Add(usuario);
            var objCambioPassword = await cambioPasswordRepository.Add(new CambioPassword
            {
                Id = Guid.NewGuid(),
                MinutosExpiracion = 60,
                Usuario = usuario,
                Activo = true,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            SendEmailUtils.SendEmail(usuario.Correo, $"({usuario.Nombres} {usuario.Apellidos})", objCambioPassword.Id.ToString());

            return Ok();


        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UserDto user)
        {
            var modificar = await userRepository.Find(x => x.Correo == user.Correo);

            if (modificar == null)
            {
                return BadRequest("El usuario no existe");
            }

            modificar.NroIdentificacion = user.NroIdentificacion;
            modificar.Nombres = user.Nombres;
            modificar.Apellidos = user.Apellidos;
            modificar.Correo = user.Correo;
            modificar.Telefono = user.Telefono;
            modificar.FechaModificacion = DateTime.Now;
            modificar.Activo = user.Activo;


            await userRepository.Edit(modificar);


            return Ok();


        }

        [HttpPost("CambioEstado")]
        public async Task<IActionResult> CambioEstado([FromBody]CambioEstadoDto user)
        {
            //1. Buscar el usuario.
            //2. Si el usuario existe, cambiar estado sino existe devolver error.
            var buscar = await userRepository.Find(x => x.Id == user.Id);

            if (buscar == null)
            {
                return BadRequest("El usuario no existe");
            }

            buscar.Activo = user.Activo;

            await userRepository.Edit(buscar);

            return Ok();
        }




        #endregion
    }
}
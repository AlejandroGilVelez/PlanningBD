using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Planning.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargarArchivoController : ControllerBase
    {
        [HttpPost("Cargar")]
        public async Task<IActionResult> Cargar([FromBody]CargarArchivoDto archivo)
        {
            //1. Buscar el usuario.
            //2. Si el usuario existe, cambiar estado sino existe devolver error.
            //var buscar = await userRepository.Find(x => x.Id == user.Id);

            //if (buscar == null)
            //{
            //    return BadRequest("El usuario no existe");
            //}

            //buscar.Activo = user.Activo;

            //await userRepository.Edit(buscar);

            return Ok();
        }
    }
}
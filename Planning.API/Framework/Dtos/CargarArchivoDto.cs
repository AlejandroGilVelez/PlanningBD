using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Dtos
{
    public class CargarArchivoDto
    {
        public string Nombre { get; set; }

        public string Extension { get; set; }

        public IFormFile archivo { get; set; }
    }
}

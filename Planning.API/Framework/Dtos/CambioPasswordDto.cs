using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Dtos
{
    public class CambioPasswordDto
    {
        public Guid Id { get; set; }

        public int MinutosExpiracion { get; set; }

        public bool Activo { get; set; }

        public string NuevoPassword { get; set; }
        
    }
}

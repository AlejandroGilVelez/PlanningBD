using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class User : BaseModel
    {
        public long NroIdentificacion { get; set; }

        [MaxLength(150)]
        [Required]
        public string Nombres { get; set; }
        [MaxLength(150)]
        [Required]
        public string Apellidos { get; set; }
        [MaxLength(200)]
        [Required]
        public string Correo { get; set; }
        [MaxLength(100)]        
        public string Telefono { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool Activo { get; set; }

        public bool CambioPassword { get; set; }
    }
}

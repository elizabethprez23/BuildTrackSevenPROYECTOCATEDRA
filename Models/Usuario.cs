using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildTrackSeven.Models
{
    public class Usuario
    {
        //se definen las propiedades de la tabla usuarios
        [Key]
        public int IdUsuario { get; set; }
        [Column("Usuario")]
        public string Nusuario { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
    }
}

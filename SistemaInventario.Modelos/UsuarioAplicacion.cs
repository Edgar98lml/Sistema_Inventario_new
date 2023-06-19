using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        [MaxLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        [MaxLength(80)]
        public int Apellidos { get; set; }

        [Required(ErrorMessage = "Direccion es requerido")]
        [MaxLength(200)]
        public int Direccion { get; set; }

        [Required(ErrorMessage = "Ciudad es requerido")]
        [MaxLength(60)]
        public int Ciudad { get; set; }

        [Required(ErrorMessage = "Pais es requerido")]
        [MaxLength(60)]
        public int Pais { get; set; }

        [NotMapped] //no se agrega a la tabla
        public string Role { get; set; }

    }
}

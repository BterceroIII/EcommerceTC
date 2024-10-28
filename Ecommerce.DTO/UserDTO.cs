using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UserDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre completo")]

        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Ingrese correo")]

        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]

        public string? Clave { get; set; }

        [Required(ErrorMessage = "Confirme su contraseña")]

        public string? ConfirmarClave { get; set; }

        public int? IdRol { get; set; }

        public virtual RolDTO? IdRolNavigation { get; set; }

    }
}

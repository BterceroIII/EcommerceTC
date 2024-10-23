using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    //nueva clase
    public partial class Rol
    {
        public int IdRol { get; set; }

        public string NombreRol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}

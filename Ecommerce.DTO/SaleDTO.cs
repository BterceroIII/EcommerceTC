using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SaleDTO
    {
        public int IdVenta { get; set; }

        public int? IdUsuario { get; set; }

        public decimal? Total { get; set; }

        public bool? Estado { get; set; }

        public string EstadoDescripcion
        {
            get
            {
                return Estado.HasValue
                    ? (Estado.Value ? "Activo" : "Inactivo")
                    : "No especificado";
            }
        }


        public virtual ICollection<SaleDetailDTO> DetalleVenta { get; set; } = new List<SaleDetailDTO>();
    }
}

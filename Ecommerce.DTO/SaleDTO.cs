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

        public bool Status { get; set; }

        public virtual ICollection<SaleDetailDTO> DetalleVenta { get; set; } = new List<SaleDetailDTO>();
    }
}

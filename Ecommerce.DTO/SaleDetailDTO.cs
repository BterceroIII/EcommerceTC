﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SaleDetailDTO
    {
        public int IdDetalleVenta { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

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
    }
}

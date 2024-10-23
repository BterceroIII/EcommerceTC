using System;
using System.Collections.Generic;
using System.Numerics;

namespace Ecommerce.Model;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    // nueva propiedad
    public string Codigo { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioOferta { get; set; }

    public int? Cantidad { get; set; }

    public string? Imagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    // nueva propiedad
    public bool Estado { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}

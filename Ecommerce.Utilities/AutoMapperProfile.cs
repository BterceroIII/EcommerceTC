using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;

namespace Ecommerce.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UserDTO>();
            CreateMap<Usuario, SessionDTO>();
            CreateMap<UserDTO, Usuario>();

            CreateMap<Categoria, CategoryDTO>();
            CreateMap<CategoryDTO, Categoria>();

            CreateMap<Producto, ProductDTO>();
            CreateMap<ProductDTO, Producto>().ForMember(destiny => 
            destiny.IdCategoriaNavigation, 
            opt => opt.Ignore());

            CreateMap<DetalleVenta, SaleDetailDTO>();
            CreateMap<SaleDetailDTO, DetalleVenta>();

            CreateMap<Venta, SaleDTO>();
            CreateMap<SaleDTO, Venta>();

        }

    }
}

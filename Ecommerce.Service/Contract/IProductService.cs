using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;

namespace Ecommerce.Service.Contract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> Catalog(string category, string search);

        Task<List<ProductDTO>> List( string search);

        Task<ProductDTO> GetProduct(int id);

        Task<ProductDTO> Create(ProductDTO model);

        Task<bool> Update(ProductDTO model);

        Task<bool> Delete(int id);
    }
}

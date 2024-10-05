using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;

namespace Ecommerce.Service.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> List( string search);

        Task<CategoryDTO> GetCategory(int id);

        Task<CategoryDTO> Create(CategoryDTO model);

        Task<bool> Update(CategoryDTO model);

        Task<bool> Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;

namespace Ecommerce.Service.Contract
{
    public interface IRolService
    {
        Task<List<RolDTO>> List(string search);

        Task<RolDTO> GetRol(int id);

        Task<RolDTO> Create(RolDTO model);

        Task<bool> Update(RolDTO model);

        Task<bool> Delete(int id);
    }
}

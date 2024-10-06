using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;
using Ecommerce.Service.Contract;

namespace Ecommerce.Service.Contract
{
    public interface ISaleService
    {
        Task<SaleDTO> Register(SaleDTO model);
    }
}

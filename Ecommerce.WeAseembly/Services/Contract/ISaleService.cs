using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface ISaleService
    {
        Task<ResponseDTO<SaleDTO>> CreateSale(SaleDTO model);
    }
}

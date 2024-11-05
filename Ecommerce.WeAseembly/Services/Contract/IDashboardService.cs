using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Sumary();
    }
}

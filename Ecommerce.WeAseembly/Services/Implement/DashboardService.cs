using System.Net.Http.Json;
using Ecommerce.WeAseembly.Services.Contract;
using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class DashboardService: IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Sumary()
        {
            return  await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Sumary");
        }
    }
}

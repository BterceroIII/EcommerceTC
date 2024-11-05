using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class SaleService: ISaleService
    {
        private HttpClient _httpClient;

        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SaleDTO>> CreateSale(SaleDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/CreateSale", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SaleDTO>>();

            return result;
        }
    }
}

using System.Net.Http.Json;
using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/Catalog/{category}/{search}");
        }

        public async Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();

            return result;
        }

        public async Task<ResponseDTO<bool>> DeleteProduct(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Product/Delete/{id}");
        }

        public async Task<ResponseDTO<ProductDTO>> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Product/Get/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> ListProduct(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/List/{search}");
        }

        public async Task<ResponseDTO<bool>> UpdateProduct(ProductDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/Update", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result;
        }
    }
}

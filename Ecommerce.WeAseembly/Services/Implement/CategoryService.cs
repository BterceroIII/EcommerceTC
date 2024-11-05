using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class CategoryService: ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/CreateCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoryDTO>>();

            return result;
        }

        public async Task<ResponseDTO<bool>> DeleteCategory(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Category/CreateCategory/{id}");
        }

        public async Task<ResponseDTO<CategoryDTO>> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoryDTO>>($"Category/CreateCategory/{id}");
        }

        public async Task<ResponseDTO<List<CategoryDTO>>> ListCategory(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoryDTO>>>($"Category/CreateCategory/{search}");
        }

        public async Task<ResponseDTO<bool>> UpdateCategory(CategoryDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/CreateCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result;
        }



    }
}

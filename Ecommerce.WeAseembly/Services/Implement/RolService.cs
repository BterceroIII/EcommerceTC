using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class RolService: IRolService
    {
        private readonly HttpClient _httpClient;

        public RolService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<RolDTO>> CreateRol(RolDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Rol/CreateRol", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<RolDTO>>();

            return result;
        }

        public async Task<ResponseDTO<bool>> DeleteRol(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Rol/DeleteRol/{id}");
        }

        public async Task<ResponseDTO<RolDTO>> GetRol(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<RolDTO>>($"Rol/GetRol/{id}");
        }

        public async Task<ResponseDTO<List<RolDTO>>> ListRol(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>($"Rol/ListRol/{search}");
        }

        public async Task<ResponseDTO<bool>> UpdateRol(RolDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Rol/CreateRol", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result;
        }
    }
}

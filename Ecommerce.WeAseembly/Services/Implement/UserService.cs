using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class UserService: IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> AuthorizationUser(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/AuthorizationUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/CreateUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> DeleteUser(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"User/DeleteUser/{id}");
        }

        public async Task<ResponseDTO<UserDTO>> GetUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"User/GetUser/{id}");
        }

        public async Task<ResponseDTO<List<UserDTO>>> ListUser(string rol, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"User/ListUser/{rol}/{search}");
        }

        public async Task<ResponseDTO<bool>> UpdateUser(UserDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("User/UpdateUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }
    }
}

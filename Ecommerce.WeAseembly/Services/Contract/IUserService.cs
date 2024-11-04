using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UserDTO>>> ListUser(string rol, string search);

        Task<ResponseDTO<UserDTO>> GetUser(int id);

        Task<ResponseDTO<SessionDTO>> AuthorizationUser(LoginDTO model);

        Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model);

        Task<ResponseDTO<bool>> UpdateUser(UserDTO model);

        Task<ResponseDTO<bool>> DeleteUser(int id);

    }
}

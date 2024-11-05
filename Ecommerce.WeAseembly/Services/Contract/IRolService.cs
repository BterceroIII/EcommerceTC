using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface IRolService
    {
        Task<ResponseDTO<List<RolDTO>>> ListRol(string search);

        Task<ResponseDTO<RolDTO>> GetRol(int id);

        Task<ResponseDTO<RolDTO>> CreateRol(RolDTO model);

        Task<ResponseDTO<bool>> UpdateRol(RolDTO model);

        Task<ResponseDTO<bool>> DeleteRol(int id);
    }
}

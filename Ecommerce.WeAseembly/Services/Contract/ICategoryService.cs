using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryDTO>>> ListCategory(string search);

        Task<ResponseDTO<CategoryDTO>> GetCategory(int id);

        Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model);

        Task<ResponseDTO<bool>> UpdateCategory(CategoryDTO model);

        Task<ResponseDTO<bool>> DeleteCategory(int id);
    }
}

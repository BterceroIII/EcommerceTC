using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductDTO>>> ListProduct(string search);

        Task<ResponseDTO<ProductDTO>> GetProduct(int id);

        Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model);

        Task<ResponseDTO<bool>> UpdateProduct(ProductDTO model);

        Task<ResponseDTO<bool>> DeleteProduct(int id);

        Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string search);
    }
}

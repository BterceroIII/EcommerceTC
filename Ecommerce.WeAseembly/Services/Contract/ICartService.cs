using Ecommerce.DTO;

namespace Ecommerce.WeAseembly.Services.Contract
{
    public interface ICartService
    {
        event Action GetItems;

        int QuantityProduct();

        Task AddCart(ShoppingCartDTO model);

        Task DeleteCart(int idProduct);

        Task<List<ShoppingCartDTO>> ReturnCart();

        Task ClearCart();
    }
}

using Blazored.LocalStorage;
using Blazored.Toast.Services;

using Ecommerce.DTO;
using Ecommerce.WeAseembly.Services.Contract;

namespace Ecommerce.WeAseembly.Services.Implement
{
    public class CartService: ICartService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CartService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action GetItems;

        public async Task AddCart(ShoppingCartDTO model)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("cart");
                if (cart == null)
                    cart = new List<ShoppingCartDTO>();

                var found = cart.FirstOrDefault(c => c.Producto.IdProducto == model.Producto.IdProducto);

                if (found != null)
                    cart.Remove(found);

                cart.Add(model);
                await _localStorageService.SetItemAsync("cart", cart);

                if (found != null)
                    _toastService.ShowSuccess("Producto fue actualizado en carrito");
                else
                    _toastService.ShowSuccess("Producto fue agregado al carrito");

                GetItems.Invoke();
            }
            catch
            {

                _toastService.ShowError("No se pudo agregar al carrito");
            }

        }

        public async Task ClearCart()
        {
            await _localStorageService.RemoveItemAsync("cart");
            GetItems.Invoke();
        }

        public async Task DeleteCart(int idProduct)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("cart");
                if(cart != null)
                {
                    var element = cart.FirstOrDefault(c => c.Producto.IdProducto == idProduct);
                    if (element != null)
                    {
                        cart.Remove(element);
                        await _localStorageService.SetItemAsync("cart", cart);
                        GetItems.Invoke();
                    }
                }

            }
            catch 
            {

                _toastService.ShowError("No se pudo eleminar del carrito");

            }
        }

        public int QuantityProduct()
        {
            var cart = _syncLocalStorageService.GetItem<List<ShoppingCartDTO>>("cart");
            return cart == null ? 0 : cart.Count();
        }

        public async Task<List<ShoppingCartDTO>> ReturnCart()
        {
            var cart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("cart");
            if(cart == null)
                cart = new List<ShoppingCartDTO>();

            return cart;
        }
    }
}

using ECommerce.Entities.Concrete;

namespace ECommerceApp.UI.Services
{
    public interface ICartSessionService
    {
        Cart? GetCart();
        void SetCart(Cart cart);
    }
}

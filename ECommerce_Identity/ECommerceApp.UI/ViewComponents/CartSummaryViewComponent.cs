using ECommerceApp.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerceApp.UI.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private readonly ICartSessionService _cartSessionService;

        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart=_cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}

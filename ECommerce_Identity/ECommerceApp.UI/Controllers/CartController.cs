using ECommerce.Entities.Concrete;
using ECommerceApp.Business.Abstract;
using ECommerceApp.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSessionService _cartSessionService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public async Task<IActionResult> AddToCart(int productId, int page, int category)
        {
            var productToBeAdded = await _productService.GetByIdAsync(productId);
            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart!, productToBeAdded);
            _cartSessionService.SetCart(cart!);

            TempData.Add("message", $"Your Product , {productToBeAdded.ProductName} was added successfully.");

            return RedirectToAction("Index", "Product", new { page = page, category = category });
        }

        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            var model = new CartListViewModel
            {
                Cart = cart!
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Complete()
        {
            var shippingDetailViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails=new ShippingDetails()
            };
            return View(shippingDetailViewModel);   
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetailsViewModel model)
        {
            if(!ModelState.IsValid) {
                return View(model);
            }
            TempData.Add("message", $"You {model.ShippingDetails.Firstname} your order is in progress.");
            return RedirectToAction("List");
        }

        public IActionResult IncreaseQuantity(int productId)
        {
            var cart = _cartSessionService.GetCart();
            var product = _productService.GetByIdAsync(productId).Result;
            _cartService.AddToCart(cart!, product);
            _cartSessionService.SetCart(cart!);
            return RedirectToAction("List");
        }

        public IActionResult DecreaseQuantity(int productId)
        {
            var cart = _cartSessionService.GetCart();
            foreach (var item in cart!.CartLines)
            {
                if (item.Product!.ProductId == productId)
                {
                    item.Quantity -= 1;
                }
            }
            _cartSessionService.SetCart(cart);
            return RedirectToAction("List");
        }
        public IActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart!, productId);
            _cartSessionService.SetCart(cart!);
            return RedirectToAction("List");
        }

    }
}

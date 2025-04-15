using ECommerceApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page = 1, int category = 0)
        {
            var items = await _productService.GetAllByCategoryId(category);
            var pageSize = 5;
            var model = new ProductListViewModel
            {
                Products=items.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                CurrentPage=page,
                PageSize=pageSize,
                PageCount=(int)Math.Ceiling(items.Count/(decimal)pageSize),
                CurrentCategory=category
            };
            return View(model);
        }
    }
}

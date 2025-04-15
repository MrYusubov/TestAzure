using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.UI.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            TempData["user"] = User.Identity.Name;
            return View();
        }
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Index2()
        {
            return View();
        }
    }
}

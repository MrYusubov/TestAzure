using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.UI.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("name", "Elvin");
            HttpContext.Session.SetInt32("age", 26);
            return Ok("Session set");
        }

        public string Get()
        {
            var name=HttpContext.Session.GetString("name");
            var age = HttpContext.Session.GetInt32("age");
            return $"Name : {name} Age : {age}";
        }
    }
}

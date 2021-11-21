using Microsoft.AspNetCore.Mvc;

namespace MyAspMvc.Controllers
{
    public class AuthController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
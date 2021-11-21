using Microsoft.AspNetCore.Mvc;

namespace MyAspMvc.Controllers
{
    public class Supply : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
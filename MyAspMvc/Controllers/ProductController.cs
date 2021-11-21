using Microsoft.AspNetCore.Mvc;

namespace MyAspMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View("Create");
        }
    }
}
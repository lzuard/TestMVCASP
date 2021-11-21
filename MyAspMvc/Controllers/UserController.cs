using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MyAspMvc.Models;

namespace MyAspMvc.Controllers
{
    public class UserController : Controller
    {
        public UserData user { get; set; }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Work(string id)
        {
            //HtmlEncoder.Default.
            ViewData["UserID"] = Convert.ToInt32(id);
            return View();
        }
    }
}
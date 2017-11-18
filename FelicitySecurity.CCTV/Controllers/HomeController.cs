using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;

namespace FelicitySecurity.CCTV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult AuthenticateAdmin()
        {
            ViewData["Message"] = "Sign in.";
            return View();
        }
        [HttpPost]
        public IActionResult AuthenticateAdmin(AdministratorModel model)
        {
            if (string.IsNullOrEmpty(model.EmailAddress) || string.IsNullOrEmpty(model.Password))
            {
                return new NotFoundResult();
            }
            ViewData["Message"] = $"Welcome {model.EmailAddress}";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

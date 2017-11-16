﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AuthenticateAdmin(string emailAddress, string password)
        {
            ViewData["Message"] = $"Welcome {emailAddress}";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

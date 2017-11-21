using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;
using System.Net;
using System.Net.Http;

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

        /// <summary>
        /// Load the Administrators log in page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AuthenticateAdmin()
        {
            ViewData["Message"] = "Sign in.";
            return View();
        }

        /// <summary>
        /// Authenticate the provided credentials.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>new page or an error </returns>
        [HttpPost]
        public IActionResult AuthenticateAdmin(AdministratorModel model)
        {
            if (string.IsNullOrEmpty(model.EmailAddress) || string.IsNullOrEmpty(model.Password))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new Exception(response.ReasonPhrase);
            }
            if (model.EmailAddress != "dbawden@outlook.com" || model.Password != "abc123")
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new Exception(response.ReasonPhrase);
            }
            //TODO retrieve credentials from db and match. If match redirect to admin session. else return validation error. 
            return RedirectToAction("AdminSession", "Home", model);
        }

        /// <summary>
        /// Load the administrators session page. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AdminSession(AdministratorModel model)
        {
            if (string.IsNullOrEmpty(model.EmailAddress))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new Exception(response.ReasonPhrase);
            }
            ViewData["Message"] = $"Welcome {model.EmailAddress}";
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

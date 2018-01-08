using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;
using FelicitySecurity.CCTV.Repository.Repository;
using Microsoft.Extensions.Configuration;
using FelicitySecurity.CCTV.Repository.Interfaces;

namespace FelicitySecurity.CCTV.Controllers
{
    public class HomeController : Controller
    {
        private ICCTVRepository repository;
        private IConfiguration configuration; 
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
            if (repository.IsAdminAuthorised(model.EmailAddress, model.Password))
            {
                return Json(model);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Load the administrators session page. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AdminSession()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

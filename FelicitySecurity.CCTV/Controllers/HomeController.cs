using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;
using FelicitySecurity.CCTV.Repository.Repository;

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
            CCTVRepository repo = new CCTVRepository();

            if (repo.IsAdminAuthorised(model.EmailAddress, model.Password))
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

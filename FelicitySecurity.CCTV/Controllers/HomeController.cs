using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;
using Microsoft.Extensions.Logging;
using FelicitySecurity.CCTV.Repository.Interfaces;

namespace FelicitySecurity.CCTV.Controllers
{
    /// <summary>
    /// The Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        private IAdministratorRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAdministratorRepository repository, ILogger<HomeController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"{this.ToString()} starting index page.");
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
            if (_repository.IsAdminAuthorised(model.EmailAddress, model.Password))
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

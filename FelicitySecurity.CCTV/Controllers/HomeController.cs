using Microsoft.AspNetCore.Mvc;
using FelicitySecurity.CCTV.Models;
using Microsoft.Extensions.Logging;
using FelicitySecurity.CCTV.Repository.Interfaces;

namespace FelicitySecurity.CCTV.Controllers
{
    /// <summary>
    /// The home controller implementing the repository pattern with Dependency injection 
    /// </summary>
    public class HomeController : Controller
    {
        private ICCTVRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICCTVRepository repository)
        {
            this._repository = repository;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

using HttpServices.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagment.web.Models;

namespace UserManagment.web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration _configuration;
        IHttpService _httpService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpService httpService)
        {
            _logger = logger;
            _configuration = configuration;
            _httpService = httpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string passcode)
        {
            var userManagmentURL = _configuration["UserManagmentIP:IpAddress"];
            var result = await _httpService.HttpPostRequest($"{userManagmentURL}/api/Users/LogIn", new { Username  = username, Password = passcode});
            if (result.IsSuccessStatusCode)                                                                                    
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                var userToken = await result.Content.ReadAsStringAsync();
                TempData["userName"] = username;
                HttpContext.Session.SetString("Token", userToken);
                return RedirectToAction("Index", "Tasks");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string username, string passcode)
        {
            var userManagmentURL = _configuration["UserManagmentIP:IpAddress"];
            var result = await _httpService.HttpPostRequest($"{userManagmentURL}/api/Users/CreateUser", new { Username = username, Password = passcode });
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = string.Format($"Regiseteration Failed {username}");
                return RedirectToAction("AddUser");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
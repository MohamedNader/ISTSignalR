using HttpServices.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagment.web.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}

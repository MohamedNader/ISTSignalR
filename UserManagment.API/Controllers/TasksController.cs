using IST.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.Bussiness.Core;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpPost("AddTaskToUser")]
        public async Task<ActionResult> AddTaskToUser(AddTaskToUser addTaskToUser)
        {
            var result = await _tasksService.AddTaskToUser(addTaskToUser);
            return Ok(result);
        }
    }
}

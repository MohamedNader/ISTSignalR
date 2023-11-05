using IST.Models.Shared;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using PushTasks.Hubs;

namespace PushTasks.Controllers
{
    public class TasksNotifyController : BaseController
    {
        [HttpPost("SendTaskToUser")]
        public async Task<ActionResult> SendTaskToUser(UserTasksDTO userTasksDTO)
        {
            var tasksHub = "";
            if (HttpContext.Request.IsHttps)
            {
                tasksHub = "https://";
            }
            else
            {
                tasksHub = "http://";
            }

            tasksHub = tasksHub + HttpContext.Request.Host.Value + "/UsersTasks";
            var connection = new HubConnectionBuilder().WithUrl(tasksHub).Build();
            await connection.StartAsync();
            //Make proxy to hub based on hub name on server
            await connection.InvokeAsync("SendTaskToUser", userTasksDTO);
            return Ok();
        }
    }
}

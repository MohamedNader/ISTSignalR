using HttpServices.Helper;
using IST.Models.DTO;
using IST.Models.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Bussiness.Core;

namespace UserManagment.Bussiness
{
    public class TasksService : ITasksService
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public TasksService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<bool> AddTaskToUser(AddTaskToUser addTaskToUser)
        {
            var notificationsServiceIp = _configuration["NotificationIP:IpAddress"];
            var userTasksDTO = new UserTasksDTO() 
            { 
                TaskId = addTaskToUser.TaskId,
                TaskName = addTaskToUser.TaskName,
                UserId = addTaskToUser.UserId
            };
            var response = await _httpService.HttpPostRequest($"{notificationsServiceIp}/api/TasksNotify/SendTaskToUser", userTasksDTO);

            return response.IsSuccessStatusCode;
        }
    }
}

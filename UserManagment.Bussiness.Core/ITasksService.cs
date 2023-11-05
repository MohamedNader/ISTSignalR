using IST.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Bussiness.Core
{
    public interface ITasksService
    {
        Task<bool> AddTaskToUser(AddTaskToUser addTaskToUser);
    }
}

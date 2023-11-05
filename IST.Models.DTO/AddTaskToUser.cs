using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST.Models.DTO
{
    public class AddTaskToUser
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
    }
}

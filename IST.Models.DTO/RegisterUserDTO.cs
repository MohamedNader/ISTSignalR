using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST.Models.DTO
{
    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public virtual string Password { get; set; }
    }
}

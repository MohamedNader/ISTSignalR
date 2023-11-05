using IST.Entities.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IST.SQLContext
{
    public class UserManagmentContext : IdentityDbContext<Users, Roles, int>
    {
        public UserManagmentContext(DbContextOptions<UserManagmentContext> options) : base(options)
        {
            
        }
    }
}
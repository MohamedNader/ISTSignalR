using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Bussiness;
using UserManagment.Bussiness.Core;

namespace UserManagment.Builder
{
    public class ServiceRegisteration
    {
        public ServiceRegisteration(IServiceCollection services)
        {
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<ITasksService, TasksService>();
        }
    }
}

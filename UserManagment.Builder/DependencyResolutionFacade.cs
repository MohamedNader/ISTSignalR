using HttpServices.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UserManagment.Builder
{
    public class DependencyResolutionFacade
    {
        public DependencyResolutionFacade(IServiceCollection services)
        {
            new ServiceRegisteration(services);
            services.AddScoped<IHttpService, HttpService>();
        }
    }
}
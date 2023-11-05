using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PushTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
            
        }
    }
}

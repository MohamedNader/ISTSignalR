using IST.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using UserManagment.Bussiness.Core;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IAccountsService _accountsService;
        IConfiguration _configuration;
        public UsersController(IAccountsService accountsService, IConfiguration configuration)
        {
            _accountsService = accountsService;
            _configuration = configuration;
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _accountsService.LogIn(loginDTO);
            if (result == null)
            {
                return NotFound();
            }

            if (result.Succeeded)
            {
                return Ok(result.Token.ToString());
            }

            return BadRequest();
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(RegisterUserDTO registerUserDTO)
        {
            var result = await _accountsService.CreateUser(registerUserDTO);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}

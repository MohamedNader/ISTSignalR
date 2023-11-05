using IST.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace UserManagment.Bussiness.Core
{
    public interface IAccountsService
    {
        Task<LoginResult> LogIn(LoginDTO loginDTO);

        Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDTO);
    }
}
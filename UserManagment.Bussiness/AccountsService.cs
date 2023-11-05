using IST.Entities.Core;
using IST.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using UserManagment.Bussiness.Core;

namespace UserManagment.Bussiness
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountsService(UserManager<Users> userManager, RoleManager<Roles> roleManager, IConfiguration configuration)
        { 
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<LoginResult> LogIn(LoginDTO loginDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user == null)
            {
                return null;
            }

            var isPasswordSuccess = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (isPasswordSuccess)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);
                var secret = _configuration.GetSection("JWT:secret").Value;
                var key = Encoding.ASCII.GetBytes(secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(token.Claims),
                    Expires = DateTime.Now.AddYears(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                return new LoginResult(true, tokenHandler.WriteToken(createdToken));
            }
            return new LoginResult(false);

        }

        public async Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDTO)
        {
            var registeredResult = await _userManager.CreateAsync(new Users()
            {
                Email = registerUserDTO.Username,
                UserName = registerUserDTO.Username
            }, registerUserDTO.Password);

            return registeredResult;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
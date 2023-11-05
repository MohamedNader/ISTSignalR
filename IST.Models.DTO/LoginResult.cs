using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST.Models.DTO
{
    public class LoginResult : SignInResult
    {
        public string Token { get; set; }
        public LoginResult(bool isSuccess, string token = null)
        {
            this.Succeeded = isSuccess;
            this.Token = token;
        }
    }
}

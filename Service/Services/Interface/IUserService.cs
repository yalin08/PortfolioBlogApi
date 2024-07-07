using Microsoft.AspNetCore.Identity;
using Business.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface IUserService
    {
        Task<SignInResult> Login(LoginDto model);
        Task<IdentityResult> Register(RegisterDto model);
        Task LogOut();
    }
}

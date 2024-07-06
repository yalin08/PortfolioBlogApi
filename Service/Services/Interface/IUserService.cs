using Microsoft.AspNetCore.Identity;
using Service.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IUserService
    {
        Task<SignInResult> Login(LoginDto model);

        Task LogOut();
    }
}

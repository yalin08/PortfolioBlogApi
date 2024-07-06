using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Service.Dto.User;
using Service.Services.Interface;


namespace Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        public async Task<SignInResult> Login(LoginDto model)
        {
            var user = await _userRepo.GetDefault(x => x.UserName.Equals(model.UserName));
         
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                return result;
            
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

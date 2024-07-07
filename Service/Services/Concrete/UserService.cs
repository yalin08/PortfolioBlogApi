using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Business.Dto.User;
using Business.Services.Interface;
using AutoMapper;


namespace Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserRepo userRepo,IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
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

        public  async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            //user.ImagePath = $"/images/01-admin.jpg";

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }
    }
}

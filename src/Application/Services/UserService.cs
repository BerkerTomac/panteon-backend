using Application.Interfaces;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(UserDto userDto)
        {
            var user = new User { UserName = userDto.Username, Email = userDto.Email };
            var result = await _userManager.CreateAsync(user, userDto.Password);
            return result;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            return result.Succeeded;
        }
    }
}

using Core.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserDto userDto);
        Task<bool> Login(LoginDto loginDto);
    }
}

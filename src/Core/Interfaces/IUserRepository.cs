// Core/Interfaces/IUserRepository.cs
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserExists(string username, string email);
        Task<User> GetUserByUsername(string username);
    }
}

using Microsoft.AspNetCore.Identity;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(User user, string password);
        Task<IdentityResult> Update(User user);
        Task<IdentityResult> Delete(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
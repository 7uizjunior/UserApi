using Microsoft.AspNetCore.Identity;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _manager;

        public UserRepository(UserManager<User> manager)
        {
            _manager = manager;
        }

        public async Task<IdentityResult> Create(User user, string password)
        {
            return await _manager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> Delete(User user)
        {
            return await _manager.DeleteAsync(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _manager.Users;
        }

        public User GetById(int id)
        {
            return _manager.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IdentityResult> Update(User user)
        {
            return await _manager.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdatePassword(User user)
        {
            return await _manager.ChangePasswordAsync(user, string.Empty, string.Empty);
        }
    }
}
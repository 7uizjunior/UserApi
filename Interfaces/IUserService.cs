using UserApi.Data.DTOs;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(CreateUserDTO dto);
        Task Update(int id, User user);
        Task Delete(int id);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
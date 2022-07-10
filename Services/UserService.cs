using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserApi.Data.DTOs;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<User> Create(CreateUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            var result = await _repository.Create(user, dto.Password);

            if (result.Succeeded)
                return user;

            else
                throw new BadHttpRequestException(string.Join(Environment.NewLine, result.Errors), 400);
        }

        public async Task Delete(int id)
        {
            var user = this.GetById(id);

            if (user != null)
                await _repository.Delete(user);

            else
                throw new BadHttpRequestException("User NotFound", 404);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task Update(int id, User user)
        {
            var user2 = this.GetById(id);

            if (user2 != null)
            {
                user.Id = user2.Id;
                await _repository.Update(user);
            }

            else
                throw new BadHttpRequestException("User NotFound", 404);
        }
    }
}
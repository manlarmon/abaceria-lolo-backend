using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            await _userRepository.CreateUserAsync(userModel);
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            await _userRepository.UpdateUserAsync(userModel);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<bool> IsUserEnabledAsync(string userEmail)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Email == userEmail);

            return user?.Enabled ?? false;
        }
    }
}

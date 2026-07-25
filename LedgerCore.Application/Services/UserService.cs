using LedgerCore.Application.DTOs;
using LedgerCore.Application.Interfaces;
using LedgerCore.Application.Mappers;
using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public UserService(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            var exists = await _userRepository.ExistsAsync(dto.Email, dto.Username);
            if (exists)
                throw new InvalidOperationException("A user with that email or username already exists.");

            var user = dto.ToUserFromRegisterDto();

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var wallet = new Wallet
            {
                UserId = user.Id,
                Balance = 0m,
                Currency = "RSD"
            };

            await _walletRepository.AddAsync(wallet);
            await _walletRepository.SaveChangesAsync();

            return user.ToUserResponseDto();
        }

        public async Task<UserResponseDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user?.ToUserResponseDto();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => u.ToUserResponseDto());
        }
    }
}

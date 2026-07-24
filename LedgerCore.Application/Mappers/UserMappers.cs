using LedgerCore.Application.DTOs;
using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Mappers
{
    public static class UserMappers
    {
        // server ka klijentu
        public static UserResponseDto ToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        // klijent ka serveru
        public static User ToUserFromRegisterDto(this RegisterUserDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
        }
    }
}

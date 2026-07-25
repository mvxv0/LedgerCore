using LedgerCore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<UserResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
    }
}

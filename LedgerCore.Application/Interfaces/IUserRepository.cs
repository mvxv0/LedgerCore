using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Interfaces
{
    public interface IUserRepository
    {

        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmail(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync (User user);
        Task<bool> ExistsAsync (string email, string  username);
        Task SaveChangesAsync();

    }
}

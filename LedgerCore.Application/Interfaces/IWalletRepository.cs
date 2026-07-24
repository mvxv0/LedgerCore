using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetByIdAsync(Guid id);
        Task<IEnumerable<Wallet>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Wallet wallet);
        Task SaveChangesAsync();
    }
}

using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<Transaction?> GetByIdempotencyKeyAsync(string idempotencyKey);
        Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId);
        Task AddAsync(Transaction transaction);
        Task SaveChangesAsync();
    }
}

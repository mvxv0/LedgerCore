using LedgerCore.Application.Interfaces;
using LedgerCore.Domain.Entities;
using LedgerCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LedgerCoreDbContext _context;
        public TransactionRepository(LedgerCoreDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Transaction?> GetByIdempotencyKeyAsync(string idempotencyKey)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(t => t.IdempotencyKey == idempotencyKey);
        }

        public async Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId)
        {
            return await _context.Transactions
                .Where(t => t.SourceWalletId == walletId || t.DestinationWalletId == walletId)
                .ToListAsync();
        }
        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using LedgerCore.Application.Interfaces;
using LedgerCore.Domain.Entities;
using LedgerCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly LedgerCoreDbContext _context;

        public WalletRepository(LedgerCoreDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet?> GetByIdAsync(Guid id)
        {
            return await _context.Wallets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Wallet>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Wallets.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

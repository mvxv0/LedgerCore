using LedgerCore.Application.Interfaces;
using LedgerCore.Domain.Entities;
using LedgerCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LedgerCoreDbContext _context;

        public UserRepository(LedgerCoreDbContext context) { 
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByEmail(string email) { 
            return await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
        }
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<bool> ExistsAsync(string email, string username)
        {
            return await _context.Users.AnyAsync(u => u.Email == email || u.Username == username);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

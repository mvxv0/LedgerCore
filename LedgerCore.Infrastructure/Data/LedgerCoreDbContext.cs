using LedgerCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

namespace LedgerCore.Infrastructure.Data
{
    public class LedgerCoreDbContext : DbContext
    {

        public LedgerCoreDbContext(DbContextOptions<LedgerCoreDbContext> options) : base(options){}

        public DbSet<User> Users => Set<User>();
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Wallets (1:N)
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Transaction -> SourceWallet (N:1), bez cascade delete
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.SourceWallet)
                .WithMany(w => w.OutgoingTransactions)
                .HasForeignKey(t => t.SourceWalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction -> DestinationWallet (N:1), bez cascade delete
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DestinationWallet)
                .WithMany(w => w.IncomingTransactions)
                .HasForeignKey(t => t.DestinationWalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision za novac (bitno za PostgreSQL!)
            modelBuilder.Entity<Wallet>()
                .Property(w => w.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Unique constraint na IdempotencyKey
            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.IdempotencyKey)
                .IsUnique();

            // Unique constraint na Email i Username
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}

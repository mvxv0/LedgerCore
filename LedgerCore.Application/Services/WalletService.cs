using LedgerCore.Application.DTOs;
using LedgerCore.Application.Exceptions;
using LedgerCore.Application.Interfaces;
using LedgerCore.Application.Mappers;
using LedgerCore.Domain.Entities;
using LedgerCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionRepository _transactionRepository;

        public WalletService(IWalletRepository walletRepository, ITransactionRepository transactionRepository)
        {
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<WalletResponseDto?> GetByIdAsync(Guid id)
        {
            var wallet = await _walletRepository.GetByIdAsync(id);
            return wallet?.ToWalletResponseDto();
        }

        public async Task<IEnumerable<WalletResponseDto>> GetByUserIdAsync(Guid userId)
        {
            var wallets = await _walletRepository.GetByUserIdAsync(userId);
            return wallets.Select(w => w.ToWalletResponseDto());
        }
        public async Task<TransactionResponseDto> DepositAsync(DepositDto dto)
        {
            if (dto.Amount <= 0)
                throw new InvalidAmountException("Iznos uplate mora biti veci od nule.");

            var existing = await _transactionRepository.GetByIdempotencyKeyAsync(dto.IdempotencyKey);
            if (existing is not null)
                return existing.ToTransactionResponseDto();

            var wallet = await _walletRepository.GetByIdAsync(dto.WalletId);
            if (wallet is null)
                throw new WalletNotFoundException(dto.WalletId);

            var transaction = new Transaction
            {
                DestinationWalletId = wallet.Id,
                Amount = dto.Amount,
                Type = TransactionType.Deposit,
                Status = TransactionStatus.Completed,
                IdempotencyKey = dto.IdempotencyKey,
                CompletedAt = DateTime.UtcNow
            };

            wallet.Balance += dto.Amount;

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();

            return transaction.ToTransactionResponseDto();
        }
    }
}

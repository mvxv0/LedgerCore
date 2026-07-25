using LedgerCore.Application.DTOs;
using LedgerCore.Application.Interfaces;
using LedgerCore.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
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
    }
}

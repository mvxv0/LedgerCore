using LedgerCore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Interfaces
{
    public interface IWalletService
    {
        Task<WalletResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<WalletResponseDto>> GetByUserIdAsync(Guid userId);
        Task<TransactionResponseDto> DepositAsync(DepositDto dto);
    }
}

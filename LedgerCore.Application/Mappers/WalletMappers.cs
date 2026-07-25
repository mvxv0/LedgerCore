using LedgerCore.Application.DTOs;
using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Mappers
{
    public static class WalletMappers
    {
        public static WalletResponseDto ToWalletResponseDto(this Wallet wallet)
        {
            return new WalletResponseDto
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                Balance = wallet.Balance,
                Currency = wallet.Currency,
                CreatedAt = wallet.CreatedAt
            };
        }
    }
}

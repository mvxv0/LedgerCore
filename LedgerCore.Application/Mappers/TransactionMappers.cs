using LedgerCore.Application.DTOs;
using LedgerCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Mappers
{
    public static class TransactionMappers
    {
        public static TransactionResponseDto ToTransactionResponseDto(this Transaction transaction)
        {
            return new TransactionResponseDto
            {
                Id = transaction.Id,
                SourceWalletId = transaction.SourceWalletId,
                DestinationWalletId = transaction.DestinationWalletId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Status = transaction.Status,
                CreatedAt = transaction.CreatedAt,
                CompletedAt = transaction.CompletedAt
            };
        }
    }
}

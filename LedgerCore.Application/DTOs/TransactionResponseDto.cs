using LedgerCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.DTOs
{
    public class TransactionResponseDto
    {
        public Guid Id { get; set; }
        public Guid? SourceWalletId { get; set; }
        public Guid? DestinationWalletId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

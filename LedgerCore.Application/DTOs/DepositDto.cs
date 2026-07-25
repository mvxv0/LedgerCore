using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.DTOs
{
    public class DepositDto
    {
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public string IdempotencyKey { get; set; } = string.Empty;
    }
}

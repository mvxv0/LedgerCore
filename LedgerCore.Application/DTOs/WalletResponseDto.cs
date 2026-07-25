using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.DTOs
{
    public class WalletResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

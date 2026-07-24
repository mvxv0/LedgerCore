using LedgerCore.Domain.Enums;


namespace LedgerCore.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? SourceWalletId { get; set; }
        public Wallet? SourceWallet { get; set; }

        public Guid? DestinationWalletId { get; set; }
        public Wallet? DestinationWallet { get; set; }

        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public string IdempotencyKey { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}

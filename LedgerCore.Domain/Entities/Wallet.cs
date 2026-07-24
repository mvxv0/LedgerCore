namespace LedgerCore.Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public decimal Balance { get; set; } = 0m;
        public string Currency { get; set; } = "RSD";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // public byte[] RowVersion { get; set; } = null!;

        // navigacija ka transakcijama
        public ICollection<Transaction> OutgoingTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction> IncomingTransactions { get; set; } = new List<Transaction>();
    }
}

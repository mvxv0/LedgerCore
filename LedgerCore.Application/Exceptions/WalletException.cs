using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerCore.Application.Exceptions
{
    public class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(Guid walletId)
            : base($"Wallet with Id {walletId} not found.") { }
    }

    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    abstract class Transaction
    {
        // Fields (private)
        private string _transactionId;
        private DateTime _transactionDate;
        private Member _member;

        // Properties (public getter, private setter)
        public string TransactionID
        {
            get { return _transactionId; }
            private set { _transactionId = value; }
        }

        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            private set { _transactionDate = value; }
        }

        public Member Member
        {
            get { return _member; }
            private set { _member = value; }
        }

        // Constructor
        public Transaction(string transactionId, DateTime transactionDate, Member member)
        {
            TransactionID = transactionId;
            TransactionDate = transactionDate;
            Member = member;
        }

        // Abstract method (phải override trong subclass)
        public abstract void Execute();

        // Display transaction info
        public void DisplayTransactionInfo()
        {
            Console.WriteLine($"Transaction ID: {TransactionID}");
            Console.WriteLine($"Transaction Date: {TransactionDate}");
            Console.WriteLine($"Member: {Member.Name}");
        }
    }
}

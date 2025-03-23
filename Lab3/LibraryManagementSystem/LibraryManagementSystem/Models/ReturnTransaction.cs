using System;

namespace LibraryManagementSystem.Models
{
    class ReturnTransaction : Transaction
    {
        // Field (private)
        private Book _bookReturned;

        // Property (getter, private setter)
        public Book BookReturned
        {
            get { return _bookReturned; }
            private set { _bookReturned = value; }
        }

        // Constructor
        public ReturnTransaction(string transactionId, DateTime transactionDate, Member member, Book book)
            : base(transactionId, transactionDate, member)  // Gọi constructor của Transaction
        {
            BookReturned = book;
        }

        // Override phương thức Execute()
        public override void Execute()
        {
            BookReturned.copiesAvailables++;  // Tăng số lượng sách có sẵn
            Console.WriteLine($"Book '{BookReturned.Title}' has been returned by {Member.Name}.");
        }
    }
}

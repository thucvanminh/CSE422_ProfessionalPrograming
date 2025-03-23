using System;

namespace LibraryManagementSystem.Models
{
    class BorrowTransaction : Transaction
    {
        // Field (private)
        private Book _bookBorrowed;

        // Property (getter, private setter)
        public Book BookBorrowed
        {
            get { return _bookBorrowed; }
            private set { _bookBorrowed = value; }
        }

        // Constructor
        public BorrowTransaction(string transactionId, DateTime transactionDate, Member member, Book book)
            : base(transactionId, transactionDate, member)  // Gọi constructor của Transaction
        {
            BookBorrowed = book;
        }

        // Override phương thức Execute()
        public override void Execute()
        {
            if (BookBorrowed.copiesAvailables > 0)
            {
                BookBorrowed.copiesAvailables--;  // Giảm số lượng sách có sẵn
                Console.WriteLine($"Book '{BookBorrowed.Title}' has been borrowed by {Member.Name}.");
            }
            else
            {
                Console.WriteLine($"Book '{BookBorrowed.Title}' is not available.");
            }
        }
    }
}

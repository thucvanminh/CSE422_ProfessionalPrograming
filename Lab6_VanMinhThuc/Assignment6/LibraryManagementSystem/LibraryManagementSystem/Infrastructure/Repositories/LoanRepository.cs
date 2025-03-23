using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LoanRepository : ILoanService
    {
        private readonly List<Loan> _loans;
        private readonly List<Book> _books;

        public LoanRepository()
        {
            // Dữ liệu mẫu
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Programming C#", Author = "Nguyen Van A", ISBN = "1234567890", IsAvailable = true },
                new Book { Id = 2, Title = "Study SQL", Author = "Tran Thi B", ISBN = "0987654321", IsAvailable = true },
                new Book { Id = 3, Title = "Design System", Author = "Le Van C", ISBN = "1122334455", IsAvailable = false }
            };

            _loans = new List<Loan>
            {
                new Loan { Id = 1, BookId = 3, UserId = 1, BorrowDate = DateTime.Now.AddDays(-5), ReturnDate = null },
                new Loan { Id = 2, BookId = 1, UserId = 2, BorrowDate = DateTime.Now.AddDays(-2), ReturnDate = DateTime.Now }
            };
        }

        public Loan GetLoan(int id)
        {
            return _loans.FirstOrDefault(l => l.Id == id);
        }

        public List<Loan> GetLoansByUser(int userId)
        {
            return _loans.Where(l => l.UserId == userId).ToList();
        }

        public void BorrowBook(int bookId, int userId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                var loan = new Loan
                {
                    Id = _loans.Any() ? _loans.Max(l => l.Id) + 1 : 1, // Tự tăng Id
                    BookId = bookId,
                    UserId = userId,
                    BorrowDate = DateTime.Now
                };
                _loans.Add(loan);
            }
        }

        public void ReturnBook(int loanId)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == loanId);
            if (loan != null && loan.ReturnDate == null)
            {
                loan.ReturnDate = DateTime.Now;
                var book = _books.FirstOrDefault(b => b.Id == loan.BookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                }
            }
        }
    }
}
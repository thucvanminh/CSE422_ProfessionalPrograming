using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanService _loanRepository;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public LoanService(ILoanService loanRepository, IBookService bookService, IUserService userService)
        {
            _loanRepository = loanRepository;
            _bookService = bookService;
            _userService = userService;
        }

        public Loan GetLoan(int id)
        {
            return _loanRepository.GetLoan(id);
        }

        public List<Loan> GetLoansByUser(int userId)
        {
            return _loanRepository.GetLoansByUser(userId);
        }

        public void BorrowBook(int bookId, int userId)
        {
            var book = _bookService.GetBook(bookId);
            var user = _userService.GetUser(userId);

            if (book == null)
            {
                throw new ArgumentException("Book not found.");
            }
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Book is not available.");
            }

            _loanRepository.BorrowBook(bookId, userId);
        }

        public void ReturnBook(int loanId)
        {
            var loan = _loanRepository.GetLoan(loanId);
            if (loan == null)
            {
                throw new ArgumentException("Loan not found.");
            }
            _loanRepository.ReturnBook(loanId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Interfaces
{
    public interface ILoanService
    {
        Loan GetLoan(int id);
        List<Loan> GetLoansByUser(int userId);
        void BorrowBook(int bookId, int userId);
        void ReturnBook(int loanId);
    }
}

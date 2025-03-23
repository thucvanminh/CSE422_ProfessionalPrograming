using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Interfaces
{
    public interface IReaderManager
    {
        void AddReader(IReader reader);
        void BorrowBook(int readerId, int bookId);
        void ReturnBook(int readerId, int bookId);
        List<IReader> GetReaders(); // Added method to access readers
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Services
{
    public class ReaderManager : Interfaces.IReaderManager
    {
        // Fields
        private readonly List<Interfaces.IReader> _readers;
        private readonly Interfaces.IBookManager _bookManager;

        // Constructor
        public ReaderManager(Interfaces.IBookManager bookManager)
        {
            _readers = new List<Interfaces.IReader>();
            _bookManager = bookManager;
        }

        public void AddReader(Interfaces.IReader reader)
        {
            if (_readers.Any(r => r.Id == reader.Id))
                throw new ArgumentException("Reader ID already exists.");
            _readers.Add(reader);
        }

        public void BorrowBook(int readerId, int bookId)
        {
            var reader = _readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null)
                throw new ArgumentException("Reader not found.");

            if (reader.BorrowedBooks.Count >= 3)
                throw new InvalidOperationException("Reader has reached borrowing limit (3 books).");

            var book = _bookManager.SearchBooks("").FirstOrDefault(b => b.Id == bookId);
            if (book == null || book.Quantity <= 0)
                throw new InvalidOperationException("Book unavailable.");

            reader.BorrowedBooks.Add(book);
            _bookManager.UpdateStock(bookId, -1);
        }

        public void ReturnBook(int readerId, int bookId)
        {
            var reader = _readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null)
                throw new ArgumentException("Reader not found.");

            var book = reader.BorrowedBooks.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
                throw new ArgumentException("Book not borrowed by this reader.");

            reader.BorrowedBooks.Remove(book);
            _bookManager.UpdateStock(bookId, 1);
        }

        public List<Interfaces.IReader> GetReaders()
        {
            return _readers;
        }
    }
}

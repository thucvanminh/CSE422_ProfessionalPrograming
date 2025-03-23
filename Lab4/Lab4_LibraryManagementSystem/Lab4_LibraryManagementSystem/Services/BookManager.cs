using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Services
{
    public class BookManager : Interfaces.IBookManager
    {
        // Fields
        private readonly List<Interfaces.IBook> _books;

        // Properties
        public List<Interfaces.IBook> Books => _books;

        // Constructor
        public BookManager()
        {
            _books = new List<Interfaces.IBook>();
        }

        public void AddBook(Interfaces.IBook book)
        {
            if (_books.Any(b => b.Id == book.Id))
                throw new ArgumentException("Book ID already exists.");
            _books.Add(book);
        }

        public List<Interfaces.IBook> SearchBooks(string query, bool byTitle = true)
        {
            if (byTitle)
                return _books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            return _books.Where(b => b.Category.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void UpdateStock(int bookId, int quantityChange)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
                throw new ArgumentException("Book not found.");
            book.Quantity += quantityChange; // Validation handled by Book.Quantity setter
        }
    }
}

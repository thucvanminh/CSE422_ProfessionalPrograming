using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookService
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            // Dữ liệu mẫu
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Programming C#", Author = "Nguyen Van A", ISBN = "1234567890", IsAvailable = true },
                new Book { Id = 2, Title = "Study SQL", Author = "Tran Thi B", ISBN = "0987654321", IsAvailable = true },
                new Book { Id = 3, Title = "Design System", Author = "Le Van C", ISBN = "1122334455", IsAvailable = false }
            };
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1; // Tự tăng Id
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.IsAvailable = book.IsAvailable;
            }
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
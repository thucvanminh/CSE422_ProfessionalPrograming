using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookRepository;

        public BookService(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public void AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.ISBN))
            {
                throw new ArgumentException("ISBN cannot be empty.");
            }
            _bookRepository.AddBook(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Interfaces
{
    public interface IBookService
    {
        Book GetBook(int id);
        List<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}


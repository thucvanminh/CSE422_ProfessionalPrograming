using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    internal class Library
    {
        // Fields
        private string _libraryName;
        private List<Book> _books;
        private List<Member> _members;

        // Properties
        public string LibraryName
        {
            get { return _libraryName; }
            set { _libraryName = value; }
        }

        public List<Book> Books
        {
            get { return _books; }
            set { _books = value ?? new List<Book>(); }
        }

        public List<Member> Members
        {
            get { return _members; }
            set { _members = value ?? new List<Member>(); }
        }

        // Delegate và Event
        public event Action<Book, Member> OnBookBorrowed;

        // Constructor
        public Library(string libraryName)
        {
            _libraryName = libraryName;
            _books = new List<Book>();
            _members = new List<Member>();
        }

        // Phương thức mượn sách, kích hoạt event
        public void BorrowBook(Book book, Member member)
        {
            if (book.copiesAvailables > 0)
            {
                book.copiesAvailables--;
                Console.WriteLine($"{member.GetName()} borrowed '{book.Title}' from {LibraryName}.");
                OnBookBorrowed?.Invoke(book, member); // Kích hoạt event
            }
            else
            {
                Console.WriteLine($"'{book.Title}' is not available.");
            }
        }

        // Hiển thị thông tin thư viện
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {_libraryName}");
            Console.WriteLine($"Total Books: {_books.Count}");
            Console.WriteLine($"Total Members: {_members.Count}");
        }
    }
}
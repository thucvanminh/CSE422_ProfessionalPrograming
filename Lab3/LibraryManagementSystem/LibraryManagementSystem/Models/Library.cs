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

        // Constructor không tham số (mặc định)
        public Library()
        {
            _libraryName = "Default Library";
            _books = new List<Book>();
            _members = new List<Member>();
        }

        // Constructor có tham số
        public Library(string libraryName, List<Book> books)
        {
            _libraryName = libraryName;
            _books = books ?? new List<Book>();
            _members = new List<Member>();
        }

        // Copy Constructor
        public Library(Library existingLibrary)
        {
            _libraryName = existingLibrary._libraryName;
            _books = new List<Book>(existingLibrary._books); // Sao chép danh sách sách
            _members = new List<Member>(existingLibrary._members); // Sao chép danh sách thành viên
        }

        // Phương thức hiển thị thông tin thư viện
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {_libraryName}");
            Console.WriteLine($"Total Books: {_books.Count}");
            Console.WriteLine($"Total Members: {_members.Count}");
        }
    }
}

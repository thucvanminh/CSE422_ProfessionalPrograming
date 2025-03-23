using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Models
{
    public class Book : IPrintable
    {
        private string _isbn;
        private string _title;
        private string _author;
        private int _year;
        private int _copiesAvailables;

        public string ISBN
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Year cannot be less than 0.");
                _year = value;

            }
        }
        public int copiesAvailables
        {
            get { return _copiesAvailables; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("CopiesAvailable cannot be less than 0.");
                _copiesAvailables = value;
            }
        }

        public Book(string isbn, string title, string author, int year, int copiesAvailable)
        {
            _isbn = isbn;
            _title = title;
            _author = author;
            _year = year;
            _copiesAvailables = copiesAvailable;
        }

        // Phương thức hiển thị thông tin sách
        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {_isbn}");
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Copies Available: {_copiesAvailables}");
            Console.WriteLine("-------------------------");
        }

        public void PrintDetails() // Triển khai IPrintable
        {
            Console.WriteLine($"ISBN: {_isbn}, Title: {_title}, Author: {_author}, Year: {_year}, Copies: {_copiesAvailables}");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BookClass
    {
        // Fields (private)
        private string _isbn;
        private string _title;
        private string _author;

        // Properties (getter/setter)
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

        // Constructor
        public BookClass(string isbn, string title, string author)
        {
            _isbn = isbn;
            _title = title;
            _author = author;
        }
    }
}

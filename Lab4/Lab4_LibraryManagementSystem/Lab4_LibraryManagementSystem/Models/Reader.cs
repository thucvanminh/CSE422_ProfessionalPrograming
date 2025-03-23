using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Models
{
    public class Reader : Interfaces.IReader
    {
        // Fields - private
        private readonly int _id;
        private readonly string _name;
        private readonly List<Interfaces.IBook> _borrowedBooks;

        // Properties (Getter & Setter)
        public int Id => _id;  // Read-only
        public string Name => _name;  // Read-only
        public List<Interfaces.IBook> BorrowedBooks => _borrowedBooks;  // Read-only

        public Reader(int id, string name)
        {
            _id = id;
            _name = name;
            _borrowedBooks = new List<Interfaces.IBook>();
        }
    }
}

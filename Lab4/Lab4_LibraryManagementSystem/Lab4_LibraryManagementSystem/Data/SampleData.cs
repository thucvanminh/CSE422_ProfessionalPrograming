using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Data
{
    public static class SampleData
    {
        public static void Initialize(Interfaces.IBookManager bookManager, Interfaces.IReaderManager readerManager)
        {
            // Sample Books
            bookManager.AddBook(new Models.PhysicalBook(1, "C# Basics", "John Doe", "Tech", 5));
            bookManager.AddBook(new Models.EBook(2, "AI Revolution", "Jane Smith", "Tech", 3));
            bookManager.AddBook(new Models.PhysicalBook(3, "Fiction 101", "Alice Brown", "Fiction", 2));

            // Sample Readers
            readerManager.AddReader(new Models.Reader(1, "Alice"));
            readerManager.AddReader(new Models.Reader(2, "Bob"));
        }
    }
}

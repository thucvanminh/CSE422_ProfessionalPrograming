using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Services
{
    public class ReportService : Interfaces.IReportService
    {
        // Fields
        private readonly Interfaces.IReaderManager _readerManager;

        // Constructor
        public ReportService(Interfaces.IReaderManager readerManager)
        {
            _readerManager = readerManager;
        }

        public string GenerateBorrowedBooksReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Borrowed Books Report:");
            foreach (var reader in _readerManager.GetReaders()) // Use GetReaders() instead of Readers
            {
                sb.AppendLine($"Reader: {reader.Name} (ID: {reader.Id})");
                if (reader.BorrowedBooks.Any())
                {
                    foreach (var book in reader.BorrowedBooks)
                    {
                        sb.AppendLine($"  - {book.Title} (ID: {book.Id})");
                    }
                }
                else
                {
                    sb.AppendLine("  - No books borrowed.");
                }
            }
            return sb.ToString();
        }
    }
}

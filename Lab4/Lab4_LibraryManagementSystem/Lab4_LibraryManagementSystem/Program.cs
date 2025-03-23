namespace Lab4_LibraryManagementSystem {
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize services
            var bookManager = new Services.BookManager();
            var readerManager = new Services.ReaderManager(bookManager);
            var reportService = new Services.ReportService(readerManager);

            // Load sample data
            Data.SampleData.Initialize(bookManager, readerManager);

            // Test functionalities
            Console.WriteLine("Adding and searching books...");
            var techBooks = bookManager.SearchBooks("Tech", false);
            foreach (var book in techBooks)
                Console.WriteLine($"{book.Title} ({book.Quantity} available)");

            Console.WriteLine("\nBorrowing books...");
            readerManager.BorrowBook(1, 1); // Alice borrows C# Basics
            readerManager.BorrowBook(2, 2); // Bob borrows AI Revolution

            Console.WriteLine("\nReport:");
            Console.WriteLine(reportService.GenerateBorrowedBooksReport());

            Console.WriteLine("\nReturning a book...");
            readerManager.ReturnBook(1, 1); // Alice returns C# Basics

            Console.WriteLine("\nUpdated Report:");
            Console.WriteLine(reportService.GenerateBorrowedBooksReport());
        }
    }
}
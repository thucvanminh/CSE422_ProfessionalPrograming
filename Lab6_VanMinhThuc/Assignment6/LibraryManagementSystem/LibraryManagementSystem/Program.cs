using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Repositories;
using LibraryManagement.Application.Services;
using LibraryManagement.Core.Entities;

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo repository
        IBookService bookRepo = new BookRepository();
        IUserService userRepo = new UserRepository();
        ILoanService loanRepo = new LoanRepository();

        // Khởi tạo service
        IBookService bookService = new BookService(bookRepo);
        IUserService userService = new UserService(userRepo);
        ILoanService loanService = new LoanService(loanRepo, bookRepo, userRepo);

        while (true)
        {
            Console.WriteLine("\n=== Library Management System ===");
            Console.WriteLine("1. All list books");
            Console.WriteLine("2. All list users");
            Console.WriteLine("3. Check user borrow history");
            Console.WriteLine("4. Add new book");
            Console.WriteLine("5. Add new user");
            Console.WriteLine("6. Borrow Book");
            Console.WriteLine("7. Return Book");
            Console.WriteLine("8. Exit");
            Console.Write("Select: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        DisplayBooks(bookService);
                        break;
                    case "2":
                        DisplayUsers(userService);
                        break;
                    case "3":
                        DisplayLoansByUser(loanService);
                        break;
                    case "4":
                        AddBook(bookService);
                        break;
                    case "5":
                        AddUser(userService);
                        break;
                    case "6":
                        BorrowBook(loanService);
                        break;
                    case "7":
                        ReturnBook(loanService);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void DisplayBooks(IBookService bookService)
    {
        var books = bookService.GetAllBooks();
        Console.WriteLine("\nAll Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id} - {book.Title} - {book.Author} - Available: {book.IsAvailable}");
        }
    }

    static void DisplayUsers(IUserService userService)
    {
        var users = userService.GetAllUsers();
        Console.WriteLine("\nAll Users:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
        }
    }

    static void DisplayLoansByUser(ILoanService loanService)
    {
        Console.Write("Type User ID: ");
        int userId = int.Parse(Console.ReadLine());
        var loans = loanService.GetLoansByUser(userId);
        Console.WriteLine($"\nBorrow history of user{userId}:");
        foreach (var loan in loans)
        {
            Console.WriteLine($"{loan.Id} - BookId: {loan.BookId} - Borrowed: {loan.BorrowDate} - Returned: {loan.ReturnDate}");
        }
    }

    static void AddBook(IBookService bookService)
    {
        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        var book = new Book { Title = title, Author = author, ISBN = isbn, IsAvailable = true };
        bookService.AddBook(book);
        Console.WriteLine("Add book sucessfully!");
    }

    static void AddUser(IUserService userService)
    {
        Console.Write("Enter user name: ");
        string name = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        var user = new User { Name = name, Email = email };
        userService.AddUser(user);
        Console.WriteLine("Add user sucessfully!");
    }

    static void BorrowBook(ILoanService loanService)
    {
        Console.Write("Enter book ID: ");
        int bookId = int.Parse(Console.ReadLine());
        Console.Write("Enter user ID: ");
        int userId = int.Parse(Console.ReadLine());

        loanService.BorrowBook(bookId, userId);
        Console.WriteLine("Borrow Book Sucessfully!");
    }

    static void ReturnBook(ILoanService loanService)
    {
        Console.Write("Enter ID borrow transaction: ");
        int loanId = int.Parse(Console.ReadLine());

        loanService.ReturnBook(loanId);
        Console.WriteLine("Return sucessfully!");
    }
}
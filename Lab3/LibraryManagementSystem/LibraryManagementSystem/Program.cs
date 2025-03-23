using System;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo đối tượng
            Library library = new Library("City Library");
            Book book = new Book("123", "Book A", "Author X", 2020, 5);
            Member member = new Member("M001", "John Doe", "john@example.com");
            NotificationService notificationService = new NotificationService();

            // Đăng ký nhiều phương thức vào event
            library.OnBookBorrowed += notificationService.SendBorrowNotification;
            library.OnBookBorrowed += notificationService.SendDetailedBorrowNotification;

            // Thực hiện mượn sách để kích hoạt event
            library.BorrowBook(book, member);

            // Kiểm tra số bản sao còn lại
            Console.WriteLine($"Copies available after borrowing: {book.copiesAvailables}");
        }
    }
}
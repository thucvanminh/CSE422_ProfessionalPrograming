using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class NotificationService
    {
        private List<Notification> notificationHistory = new List<Notification>();



        public virtual void SendNotification(string message)
        {
            Notification notification = new Notification(message);
            notificationHistory.Add(notification);
            notification.DisplayNotification();
        }

        public void SendNotification(string message, string recipient)
        {
            Notification notification = new Notification(message, recipient);
            notificationHistory.Add(notification);
            notification.DisplayNotification();
        }

        public void SendNotification(string message, List<string> recipients)
        {
            foreach (var recipient in recipients)
            {
                Notification notification = new Notification(message, recipient);
                notificationHistory.Add(notification);
                notification.DisplayNotification();
            }
        }


        public void SendBorrowNotification(Book book, Member member)
        {
            Console.WriteLine($"[Notification] {member.GetName()} has borrowed '{book.Title}' on {DateTime.Now:yyyy-MM-dd HH:mm:ss}.");
        }

        // Phương thức gửi thông báo chi tiết (ví dụ thêm một handler khác)
        public void SendDetailedBorrowNotification(Book book, Member member)
        {
            Console.WriteLine($"[Detailed Notification] Book: '{book.Title}', ISBN: {book.ISBN}, Borrowed by: {member.GetName()} (ID: {member.GetMemberID()}).");
        }



        // Xem lại lịch sử thông báo
        public void ShowNotificationHistory()
        {
            Console.WriteLine("\n--- Notification History ---");
            foreach (var notification in notificationHistory)
            {
                notification.DisplayNotification();
            }
        }
    }
}

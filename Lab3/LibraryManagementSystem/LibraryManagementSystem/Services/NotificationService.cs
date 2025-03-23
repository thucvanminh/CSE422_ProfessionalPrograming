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

namespace LibraryManagementSystem.Services
{
    public class AdvancedNotificationService : NotificationService
    {
        public override void SendNotification(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[Advanced Notification] [{timestamp}] {message}");
        }
    }
}

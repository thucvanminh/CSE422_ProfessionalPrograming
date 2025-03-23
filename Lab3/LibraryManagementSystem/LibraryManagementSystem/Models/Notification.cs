namespace LibraryManagementSystem.Models
{
    public class Notification
    {
        public string Message { get; private set; }
        public string Recipient { get; private set; }
        public DateTime SentTime { get; private set; }

        // Constructor mặc định
        public Notification(string message)
        {
            Message = message;
            SentTime = DateTime.Now;
            Recipient = "All"; // Mặc định là thông báo chung
        }

        // Constructor với người nhận
        public Notification(string message, string recipient)
        {
            Message = message;
            Recipient = recipient;
            SentTime = DateTime.Now;
        }

        // Hiển thị thông tin thông báo
        public void DisplayNotification()
        {
            Console.WriteLine($"[{SentTime:yyyy-MM-dd HH:mm:ss}] To {Recipient}: {Message}");
        }
    }
}

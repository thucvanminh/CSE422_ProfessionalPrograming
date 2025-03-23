using Assignment1;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            logger.Log("LogUserAction", "john", "login");
            logger.Log("LogTransaction", 123, 45.67);
            logger.Log("LogError", "Invalid input", DateTime.Now);
        }
    }
}

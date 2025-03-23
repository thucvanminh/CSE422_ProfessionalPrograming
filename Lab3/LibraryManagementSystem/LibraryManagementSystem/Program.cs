using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

class Program
{
    static void Main(string[] args)
    {
        Member member = new Member("M001", "John Doe", "john@example.com");
        LibraryCard card = new LibraryCard("C123", member);
        Console.WriteLine($"Card Number: {card.CardNumber}, Owner: {card.Owner.Name}, Issue Date: {card.IssueDate:yyyy-MM-dd}");
        card.RenewCard();
    }
}

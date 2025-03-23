namespace Lab4_LibraryManagementSystem.Interfaces
{
    public interface IBook
    {
        int Id { get; }
        string Title { get; }
        string Author { get; }
        string Category { get; }
        int Quantity { get; set; }
    }
}
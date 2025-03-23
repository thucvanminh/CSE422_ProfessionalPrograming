namespace Lab4_LibraryManagementSystem.Interfaces
{
    public interface IBookManager
    {
        void AddBook(IBook book);
        List<IBook> SearchBooks(string query, bool byTitle = true);
        void UpdateStock(int bookId, int quantityChange);
    }
}
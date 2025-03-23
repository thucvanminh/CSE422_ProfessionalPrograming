using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Interfaces
{
    public interface IReader
    {
        int Id { get; }
        string Name { get; }
        List<IBook> BorrowedBooks { get; }
    }
}


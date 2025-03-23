using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Models
{
    public class EBook : Book
    {
        public EBook(int id, string title, string author, string category, int quantity)
            : base(id, title, author, category, quantity)
        {
        }
    }
}

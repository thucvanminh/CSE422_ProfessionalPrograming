using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LibraryManagementSystem.Models
{
    public abstract class Book : Interfaces.IBook
    {
        // Fields - private
        private readonly int _id;
        private readonly string _title;
        private readonly string _author;
        private readonly string _category;
        private int _quantity;

        // Properties (Getter & Setter)
        public int Id => _id;  // Read-only
        public string Title => _title;  // Read-only
        public string Author => _author;  // Read-only
        public string Category => _category;  // Read-only

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value >= 0)  // Validate quantity
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
            }
        }

        protected Book(int id, string title, string author, string category, int quantity)
        {
            _id = id;
            _title = title;
            _author = author;
            _category = category;
            if (quantity >= 0)
            {
                _quantity = quantity;
            }
            else
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
        }
    }
}

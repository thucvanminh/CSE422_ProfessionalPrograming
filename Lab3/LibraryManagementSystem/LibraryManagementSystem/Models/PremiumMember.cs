using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;
using Microsoft.VisualBasic;

namespace LibraryManagementSystem.Models
{
    internal class PremiumMember : Member, IMemberActions
    {
        private DateTime _membershipExpiry;
        private int _maxBooksAllowed;
        private int _booksBorrowed; // Theo dõi số sách đã mượn
        public DateTime MembershipExpiry
        {
            get { return _membershipExpiry; }
            set { _membershipExpiry = value; }
        }
        public int MaxBooksAllowed
        {
            get { return _maxBooksAllowed; }
            set { _maxBooksAllowed = value; }
        }


        public PremiumMember(string memberId, string name, string email, DateTime expiry, int maxBooks)
            : base(memberId, name, email)
        {
            _membershipExpiry = expiry;
            _maxBooksAllowed = maxBooks;
            _booksBorrowed = 0; // Khởi tạo số sách đã mượn
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Membership Expiry: {_membershipExpiry.ToShortDateString()}");
            Console.WriteLine($"Max Books Allowed: {_maxBooksAllowed}");
            Console.WriteLine("-------------------------");
        }


        public void BorrowBook(Book book)
        {
            if (_booksBorrowed < _maxBooksAllowed)
            {
                if (book.copiesAvailables > 0)
                {
                    book.copiesAvailables--;
                    _booksBorrowed++;
                    Console.WriteLine($"{Name} (Premium) borrowed '{book.Title}'. Books borrowed: {_booksBorrowed}/{_maxBooksAllowed}");
                }
                else
                {
                    Console.WriteLine($"'{book.Title}' is not available.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} has reached the borrowing limit ({_maxBooksAllowed} books).");
            }
        }

        public void ReturnBook(Book book)
        {
            book.copiesAvailables++;
            if (_booksBorrowed > 0)
            {
                _booksBorrowed--;
            }
            Console.WriteLine($"{Name} (Premium) returned '{book.Title}'. Books borrowed: {_booksBorrowed}/{_maxBooksAllowed}");
        }



    }
}

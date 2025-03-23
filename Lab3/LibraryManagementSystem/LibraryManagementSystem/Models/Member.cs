using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Models
{
    public class Member : IPrintable, IMemberActions
    {
        private string _memberId;
        private string _name;
        private string _email;

        public string MemberID { get { return _memberId; } set { _memberId = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }

        public Member(string memberId, string name, string email)
        {
            _memberId = memberId;
            _name = name;
            _email = email;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine("-------------------------");
        }

        void IMemberActions.BorrowBook(Book book)
        {
            if (book.copiesAvailables > 0)
            {
                book.copiesAvailables--;
                Console.WriteLine($"{_name} borrowed '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"'{book.Title}' is not available.");
            }
        }

        void IMemberActions.ReturnBook(Book book)
        {
            book.copiesAvailables++;
            Console.WriteLine($"{_name} returned '{book.Title}'.");
        }

        void IPrintable.PrintDetails()
        {
            Console.WriteLine($"Member ID: {_memberId}, Name: {_name}, Email: {_email}");
        }

        public string GetMemberID()
        {
            return _memberId;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetEmail()
        {
            return _email;
        }
    }
}

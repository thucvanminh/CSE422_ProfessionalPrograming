using System;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Models
{
    internal class LibraryCard
    {
        private readonly string _cardNumber; // read-only
        private Member _owner; // read and write
        private DateTime _issueDate; // read-only externally

        public string CardNumber
        {
            get { return _cardNumber; }
        }

        public Member Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public DateTime IssueDate
        {
            get { return _issueDate; }
            private set { _issueDate = value; } // private setter
        }

        // Constructor
        public LibraryCard(string cardNumber, Member owner)
        {
            _cardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            _issueDate = DateTime.Now; // Ngày phát hành mặc định là hiện tại
        }

        // Phương thức gia hạn thẻ
        public void RenewCard()
        {
            _issueDate = DateTime.Now; // Cập nhật ngày phát hành mới
            Console.WriteLine($"Card {CardNumber} renewed for {_owner.Name}. New Issue Date: {_issueDate:yyyy-MM-dd}");
        }
    }
}
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            // Dữ liệu mẫu
            _users = new List<User>
            {
                new User { Id = 1, Name = "Nguyen Van X", Email = "x@example.com" },
                new User { Id = 2, Name = "Tran Thi Y", Email = "y@example.com" }
            };
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public void AddUser(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1; // Tự tăng Id
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
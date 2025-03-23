using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Interfaces
{
    public interface IUserService
    {
        User GetUser(int id);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}

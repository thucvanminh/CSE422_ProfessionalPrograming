using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class UserService : IService
    {
        public string Get(int id)
        {
            // Simulate heavy DB query
            Console.WriteLine("Fetching user from database...");
            return $"User {id}";
        }
    }
}

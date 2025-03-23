using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class CacheDecorator : IService
    {
        private readonly IService _service;
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

        public CacheDecorator(IService service)
        {
            _service = service;
        }

        public string Get(int id)
        {
            if (_cache.ContainsKey(id))
            {
                Console.WriteLine("Fetching from cache...");
                return _cache[id];
            }

            string result = _service.Get(id);
            _cache[id] = result;
            return result;
        }
    }
}

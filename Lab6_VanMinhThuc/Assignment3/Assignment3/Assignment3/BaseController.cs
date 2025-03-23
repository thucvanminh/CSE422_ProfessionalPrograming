using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public abstract class BaseController<T> : ControllerBase where T : class, IEntity
    {
        [HttpPost]
        public IActionResult Create(T entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.Name))
            {
                return BadRequest("Invalid data");
            }
            return Ok($"{typeof(T).Name} {entity.Name} created successfully.");
        }
    }
}

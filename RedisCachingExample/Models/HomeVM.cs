using Model.Models;
using System.Collections.Generic;

namespace RedisCachingExample.Models
{
    public class HomeVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}

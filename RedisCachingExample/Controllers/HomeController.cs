using Data.Managers;
using Model.Models;
using RedisCachingExample.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RedisCachingExample.Controllers
{
    public class HomeController : Controller
    {
        private BlogExContext _db;

        public HomeController()
        {
            _db = new BlogExContext();
        }

        public async Task<ActionResult> Index()
        {
            var cacheManager = new CacheManager();
            var vm = new HomeVM
            {
                Categories = cacheManager.Get<List<Category>>("redisCategories"),
                Posts = cacheManager.Get<List<Post>>("redisPosts")
            };


            /*
            var vm = new HomeVM
            {
                Categories = await _db.Categories.ToListAsync(),
                Posts = await _db.Posts.ToListAsync()
            };
            */

            return View(vm);
        }
    }
}

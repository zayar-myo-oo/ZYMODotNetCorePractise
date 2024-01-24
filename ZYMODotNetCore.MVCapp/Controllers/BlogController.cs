using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZYMODotNetCore.MVCapp.Models;

namespace ZYMODotNetCore.MVCapp.Controllers
{ // https://localhost:3000/blog/index
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            // "select * from tbl_blog with (nolock)"
            List<BlogDataModel> lst = await _appDbContext.Blogs.AsNoTracking().ToListAsync();
            //return View();
            return View("BlogIndex", lst);
        }
    }
}

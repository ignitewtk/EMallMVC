using EMallMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMallMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Product != null ?
                View(await _context.Product.ToListAsync()) :
                Problem("Entity set 'AppDbContext.Product'  is null.");
            // return View();
        }

    }
}

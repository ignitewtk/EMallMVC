using System;
using EMallMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMallMVC.Models;

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
        }

        // GET: Product
        public async Task<IActionResult> Details(int? productId)
        {
            Console.WriteLine("Route to GET Details ..................");
            if (productId == null)
            {
                Console.WriteLine(productId);
                Console.WriteLine("id {0} null ..................", productId);
                return NotFound();
            }

            if (_context.Product == null)
            {
                Console.WriteLine("context product null ..................");
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId, ProductName, ProductCategory, ProductDescription, ModifiedDate, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync(); 
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? productId)
        {
            if (productId == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Products/Edit/5
        public async Task<IActionResult> Edit(
            int? productId, [Bind("ProductId, ProductName, ProductCategory, ProductDescription, ModifiedDate, Price")] Product product)
        {
            if (productId != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? productId)
        {
            if (productId == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == productId);
            if (product == null )
            {
                return NotFound();
            }
            return View(product);
        }

        //POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int productId)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'AppDbContext.Product' is null.");
            }
            var product = await _context.Product.FindAsync(productId);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int productId)
        {
            return (_context.Product?.Any(e => e.ProductId == productId)).GetValueOrDefault();
        }
    }
}

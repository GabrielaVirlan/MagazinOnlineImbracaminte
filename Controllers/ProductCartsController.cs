using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinOnlineImbracaminte.Models;
using MagazinOnlineImbracaminte.Data;

namespace MagazinOnlineImbracaminte.Controllers
{
    public class ProductCartsController : Controller
    {
        private readonly MagazinOnlineImbracaminteContext _context;

        public ProductCartsController(MagazinOnlineImbracaminteContext context)
        {
            _context = context;
        }

        // GET: ProductCarts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCarts.ToListAsync());
        }

        // GET: ProductCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCarts
                .FirstOrDefaultAsync(m => m.ProductCartId == id);
            if (productCart == null)
            {
                return NotFound();
            }

            return View(productCart);
        }

        // GET: ProductCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCartId")] ProductCart productCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCart);
        }

        // GET: ProductCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCarts.FindAsync(id);
            if (productCart == null)
            {
                return NotFound();
            }
            return View(productCart);
        }

        // POST: ProductCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCartId")] ProductCart productCart)
        {
            if (id != productCart.ProductCartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCartExists(productCart.ProductCartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productCart);
        }

        // GET: ProductCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCarts
                .FirstOrDefaultAsync(m => m.ProductCartId == id);
            if (productCart == null)
            {
                return NotFound();
            }

            return View(productCart);
        }

        // POST: ProductCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCart = await _context.ProductCarts.FindAsync(id);
            _context.ProductCarts.Remove(productCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCartExists(int id)
        {
            return _context.ProductCarts.Any(e => e.ProductCartId == id);
        }
    }
}

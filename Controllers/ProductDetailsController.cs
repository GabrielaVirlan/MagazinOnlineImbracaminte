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
    public class ProductDetailsController : Controller
    {
        private readonly MagazinOnlineImbracaminteContext _context;

        public ProductDetailsController(MagazinOnlineImbracaminteContext context)
        {
            _context = context;
        }

        // GET: ProductDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductDetailss.ToListAsync());
        }

        // GET: ProductDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetails = await _context.ProductDetailss
                .FirstOrDefaultAsync(m => m.ProductDetailsId == id);
            if (productDetails == null)
            {
                return NotFound();
            }

            return View(productDetails);
        }

        // GET: ProductDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductDetailsId,Size,Material,Color")] ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDetails);
        }

        // GET: ProductDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetails = await _context.ProductDetailss.FindAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }
            return View(productDetails);
        }

        // POST: ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductDetailsId,Size,Material,Color")] ProductDetails productDetails)
        {
            if (id != productDetails.ProductDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDetailsExists(productDetails.ProductDetailsId))
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
            return View(productDetails);
        }

        // GET: ProductDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDetails = await _context.ProductDetailss
                .FirstOrDefaultAsync(m => m.ProductDetailsId == id);
            if (productDetails == null)
            {
                return NotFound();
            }

            return View(productDetails);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _context.ProductDetailss.FindAsync(id);
            _context.ProductDetailss.Remove(productDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDetailsExists(int id)
        {
            return _context.ProductDetailss.Any(e => e.ProductDetailsId == id);
        }
    }
}

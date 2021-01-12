using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinOnlineImbracaminte.Models;
using MagazinOnlineImbracaminte.Data;
using MagazinOnlineImbracaminte.Helpers;

namespace MagazinOnlineImbracaminte.Controllers
{
    public class CartsController : Controller
    {
        private readonly MagazinOnlineImbracaminteContext _context;

        public CartsController(MagazinOnlineImbracaminteContext context)
        {
            _context = context;
        }


        /*  private int isExist(int id)
          {
              Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
              int index = 0;
              foreach (Product productId in cart.ProductCart.Products)
              {
                  if (product.ProductId.Equals(id))
                  {
                      return index;
                  }
                  index++;
              }
              return -1;
          } */


        

        //public async task addproducttocartasync(int id, int quantity)
        //{
        //caz1: nu exista cart - ul
        //    if (sessionhelper.getobjectfromjson<cart>(httpcontext.session, "cart") == null)
        //    {
        //        instantiere cart cu id 0;
        //        cart cart = new cart();
        //        cart.cartid = 0;

        //        instantiere productcart cu id 0;
        //        cart.productcart.productcartid = 0;

        //        creare / initializare productcart;
        //        var product = await _context.products
        //            .firstordefaultasync(m => m.productid == id);
        //        cart.productcart.productid = id;
        //        cart.productcart.cartid = cart.cartid;

        //        adaugare product in productcart in cart;
        //        cart.productcart.productqunatity = quantity;
        //        cart.productcart.products.add(product);

        //    }
        //    caz 1: exista cart-ul
        //    else
        //    {
        //        productcart productcart = sessionhelper.getobjectfromjson<productcart>(httpcontext.session, "cart");

        //        foreach (var product in productcart.products)
        //        {
        //            daca produsul exista in cart, deja;
        //            if (product.productid == id)
        //            {
        //                productcart.productqunatity += quantity;

        //            }
        //            produsul nu exista in cos;
        //            else
        //            {
        //                instantiere productcart cu id 0;
        //                cart.productcart.productcartid = 0;

        //                creare / initializare productcart;
        //                var product2 = await _context.products
        //                    .firstordefaultasync(m => m.productid == id);
        //                cart.productcart.productid = id;
        //                cart.productcart.cartid = cart.cartid;

        //                adaugare product in productcart in cart;
        //                cart.productcart.productqunatity = quantity;
        //                cart.productcart.products.add(product2);
        //            }
        //        }


          //  }
        //}


       /* public async Task<IActionResult> Buy(int id)
        {
            if(SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart") == null)
            {
                //adaugarea produsului in lista de produse in cosul cu indexul 0
                var product = await _context.Products
                    .FirstOrDefaultAsync(m => m.ProductId == id);

                Cart cart = new Cart { CartId = 0, ProductCart = new ProductCart(), DeliveryAdress = new Delivery(), User = new User()};

                // instantiez lista de produse de tip ICollectio cu List<Products>
                List<Product> products = new List<Product>();
                products.Add(product);

                cart.ProductCart.Products = products;

                _context.Carts.Add(cart);

                _context.SaveChanges();

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart.ProductCart.Products.ElementAt(index);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }*/

        /*public async Task<IActionResult> Remove(int id)
        {
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            int index = isExist(id);
            var product = await _context.Products
                        .FirstOrDefaultAsync(m => m.ProductId== id);
            cart.ProductCart.Products.Remove(product);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        */
        // GET: Carts
        public IActionResult Index()
        {

            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            ViewData["cart"] = cart;
            //ViewData["total"] = cart.Sum(Product => Product.Price * Product.Quantities);

            return View();
        }

        public async Task<IActionResult> AddProductToCartAsync(int ProductId)
        {
            var carts = SessionHelper.GetObjectFromJson<DbSet<Cart>>(HttpContext.Session, "carts");
            var productCarts = SessionHelper.GetObjectFromJson<DbSet<ProductCart>>(HttpContext.Session, "productCarts");
            var product = await _context.Products
                    .FirstOrDefaultAsync(m => m.ProductId == ProductId);
            if (!carts.Any())
            {
                Cart cart = new Cart();
                cart.CartId = 0;
                //carts.Add(cart);

                _context.Carts.Add(cart);

                ProductCart productCart = new ProductCart();
                productCart.ProductCartId = 0;
                productCart.ProductId = ProductId;
                productCart.CartId = cart.CartId;
                productCart.ProductQunatity = 1;

                _context.ProductCarts.Add(productCart);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "carts", _context.Carts);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "productCarts", _context.ProductCarts);

            }

            return View(product);
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}

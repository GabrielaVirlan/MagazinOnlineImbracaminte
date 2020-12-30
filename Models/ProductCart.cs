using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class ProductCart
    {

        public int ProductCartId { get; set; }
        //relatie one to many : Carts <-> ProductCart
        public ICollection<Cart> Carts { get; set; }

        //relatie one to many : Product <-> ProductCart
        public ICollection<Product> Products { get; set; }

    }
}

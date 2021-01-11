using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace MagazinOnlineImbracaminte.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public bool InStock { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        [Range(0, 100, ErrorMessage = "Nu exista mai mult de 100 de produse in stoc!")]
        public int QuantityInStock { set; get; }
        [Range(0, 10, ErrorMessage = "Nu puteti introduce mai mult de 10 produse in cos!")]

        public ProductDetails ProductDetails { get; set; }

        //relatie one to many : Product <-> ProductCart
        public int ProductCartID { get; set; }




    }
}

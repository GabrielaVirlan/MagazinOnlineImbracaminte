using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class ProductDetails
    {
        [Key]
        public int ProductDetailsId { get; set; }
        [MaxLength(10)]
        public string Size { set; get; }
        [MaxLength(50)]
        public string Material { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }

        //relatie one to many: Product <-> ProductDetails
        public ICollection<Product> Products { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class ProductCart
    {
        [Key]
        public int ProductCartId { get; set; }
        //relatie one to many : Carts <-> ProductCart

        public int ProductQunatity { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }

    }
}

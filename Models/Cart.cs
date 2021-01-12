using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        //relatie  unu la unu : Cart <-> Delivery
        public Delivery DeliveryAdress { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class Delivery
    {
        [ForeignKey("DeliveyAdress")]
        public int DeliveryId { get; set; }
        public User User { set; get; }
        [MaxLength(30)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string Street { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Numarul introdus nu este valid!")]
        public int Number { get; set; }
        //relatie unu la unu : Cart <-> Delivery
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}

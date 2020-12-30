using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string EmailAdress { get; set; }
        [MaxLength(50)]
        public string Passworld { get; set; }

        //one to many : User -> UserRole
        public UserRole UserRole { get; set; }

        //one to many : Cart <-> User
        public virtual ICollection<Cart> Carts { get; set; }

    }
}

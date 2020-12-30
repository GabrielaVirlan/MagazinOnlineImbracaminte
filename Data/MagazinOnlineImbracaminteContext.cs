using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagazinOnlineImbracaminte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MagazinOnlineImbracaminte.Data
{
    public class MagazinOnlineImbracaminteContext : IdentityDbContext
    {
        public MagazinOnlineImbracaminteContext (DbContextOptions<MagazinOnlineImbracaminteContext> options)
            : base(options)
        {
        }

        public DbSet<MagazinOnlineImbracaminte.Models.Cart> Carts { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.Product> Products { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.Delivery> Deliveries { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.ProductCart> ProductCarts { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.ProductDetails> ProductDetailss { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.Role> Roles { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.UserRole> UserRoles { get; set; }

        public DbSet<MagazinOnlineImbracaminte.Models.User> Users { get; set; }
    }
}

using MagazinOnlineImbracaminte.Data;
using MagazinOnlineImbracaminte.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace MagazinOnlineImbracaminte.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                using var context = new MagazinOnlineImbracaminteContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<MagazinOnlineImbracaminteContext>>());

                if (context.Users.Any() && context.Roles.Any() && context.Products.Any() && context.ProductDetailss.Any() && context.UserRoles.Any())
                {
                    return;   // DB has been seeded
                }

                context.UserRoles.AddRange(
                    new UserRole
                    {
                        //UserRoleId = 1,
                        Roles = new List<Role>
                        {
                        new Role {Name = "Utilizator"}
                        }
                    },

                    new UserRole
                    {
                        //UserRoleId = 2,
                        Roles = new List<Role>
                        {
                        new Role { Name = "Administrator"},
                        new Role { Name = "Utilizator"}
                        }
                    },

                    new UserRole
                    {
                        //UserRoleId = 3,
                        Roles = new List<Role>
                        {
                        new Role { Name = "Guest"},
                        }
                    },

                    new UserRole
                    {
                        //UserRoleId = 4,
                        Roles = new List<Role>
                        {
                        new Role { Name = "Administrator"},
                        }
                    }

                );


                context.Users.AddRange(
                    new User
                    {
                        //UserId = 1,
                        FirstName = "Ana",
                        LastName = "Aanei",
                        PhoneNumber = "0711111111",
                        EmailAdress = "AaneiAna@gmail.com",
                        Passworld = "anaana",
                        UserRole = new UserRole
                        {
                            Roles = new List<Role>
                            {
                            new Role { Name = "Administrator"},
                            new Role { Name = "Utilizator"}
                            }
                        }
                    },

                    new User
                    {
                        //UserId = 2,
                        FirstName = "Bianca",
                        LastName = "Banisor",
                        PhoneNumber = "0722222222",
                        EmailAdress = "BiancaBanisor@gmail.com",
                        Passworld = "biancabianca",
                        UserRole = new UserRole
                        {
                            Roles = new List<Role>
                            {
                            new Role { Name = "Utilizator"}
                            }
                        }
                    }
                );

                context.ProductDetailss.AddRange(
                    new ProductDetails
                    {
                        //ProductDetailsId = 1,
                        Size = "M",
                        Material = "In",
                        Color = "Crem"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 2,
                        Size = "S",
                        Material = "Bumbac",
                        Color = "Portocaliu"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 3,
                        Size = "L",
                        Material = "Bumbac",
                        Color = "Roz"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 4,
                        Size = "42",
                        Material = "Blug",
                        Color = "Albastru"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 5,
                        Size = "S",
                        Material = "In",
                        Color = "Galben"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 6,
                        Size = "S",
                        Material = "Vascoza",
                        Color = "Verde"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 7,
                        Size = "XL",
                        Material = "Bumbac",
                        Color = "Visiniu"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 8,
                        Size = "38-42",
                        Material = "Bumbac Organic",
                        Color = "Model Banane"
                    },

                    new ProductDetails
                    {
                        //ProductDetailsId = 9,
                        Size = "42 - 48",
                        Material = "Bumbac Organic",
                        Color = "Model Craciun"
                    }
                );

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Bluza Crem",
                        InStock = true,
                        Price = 89.99f,
                        Image = "~/Photos/Bluza_Crem.jpg",
                        QuantityInStock = 10,
                        ProductDetails = new ProductDetails
                        {
                            Size = "M",
                            Material = "In",
                            Color = "Crem"
                        }
                    },

                    new Product
                    {
                        Name = "Bluza Portocalie",
                        InStock = true,
                        Price = 79.99f,
                        Image = "~/Photos/Bluza_Portocalie.jpg",
                        QuantityInStock = 6,
                        ProductDetails = new ProductDetails
                        {
                            Size = "S",
                            Material = "Bumbac",
                            Color = "Portocaliu"
                        }
                    },

                    new Product
                    {
                        Name = "Bluza Roz",
                        InStock = true,
                        Price = 99.99f,
                        Image = "~/Photos/Bluza_Roz.jpg",
                        QuantityInStock = 3,
                        ProductDetails = new ProductDetails
                        {
                            Size = "L",
                            Material = "Bumbac",
                            Color = "Roz"
                        }
                    },

                    new Product
                    {
                        Name = "Jeans Dama",
                        InStock = true,
                        Price = 99.99f,
                        Image = "~/Photos/Jeans.jpg",
                        QuantityInStock = 5,
                        ProductDetails = new ProductDetails
                        {
                            Size = "42",
                            Material = "Blug",
                            Color = "Albastru"
                        }
                    },

                    new Product
                    {
                        Name = "Rochie Galbena",
                        InStock = true,
                        Price = 89.99f,
                        Image = "~/Photos/Rochie_Galbena.jpg",
                        QuantityInStock = 2,
                        ProductDetails = new ProductDetails
                        {
                            Size = "S",
                            Material = "In",
                            Color = "Galben"
                        }
                    },

                    new Product
                    {
                        Name = "Rochie Roz",
                        InStock = true,
                        Price = 79.99f,
                        Image = "~/Photos/Rochie_Roz.jpg",
                        QuantityInStock = 1,
                        ProductDetails = new ProductDetails
                        {

                        }
                    },

                    new Product
                    {
                        Name = "Rochie Verde",
                        InStock = false,
                        Price = 84.99f,
                        Image = "~/Photos/Rochie_Verde.jpg",
                        QuantityInStock = 0,
                        ProductDetails = new ProductDetails
                        {
                            Size = "L",
                            Material = "Bumbac",
                            Color = "Roz"
                        }
                    },

                    new Product
                    {
                        Name = "Rochie Visinie",
                        InStock = false,
                        Price = 84.99f,
                        Image = "~/Photos/Rochie_Visinie.jpg",
                        QuantityInStock = 0,
                        ProductDetails = new ProductDetails
                        {
                            Size = "XL",
                            Material = "Bumbac",
                            Color = "Visiniu"
                        }
                    },

                    new Product
                    {
                        Name = "Sosete Banane",
                        InStock = true,
                        Price = 19.99f,
                        Image = "~/Photos/Sosete_Banane.jpg",
                        QuantityInStock = 10,
                        ProductDetails = new ProductDetails
                        {
                            Size = "38-42",
                            Material = "Bumbac Organic",
                            Color = "Model Banane"
                        }
                    },
                    new Product
                    {
                        Name = "Sosete Craciun",
                        InStock = true,
                        Price = 24.99f,
                        Image = "~/Photos/Sosete_Craciun.jpg",
                        QuantityInStock = 9,
                        ProductDetails = new ProductDetails
                        {
                            Size = "42 - 48",
                            Material = "Bumbac Organic",
                            Color = "Model Craciun"
                        }
                    }
                );

                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
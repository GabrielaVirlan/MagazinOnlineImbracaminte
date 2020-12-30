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
    public class Role : IdentityRole
    {
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        //relatie one to many : Role <-> UserRole
        public UserRole UserRole { get; set; }
    }
}

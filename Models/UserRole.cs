using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models
{
    public class UserRole
    {

        public int UserRoleId { get; set; }

        //relatie one to many : User <-> UserRole
        public ICollection<User> Users { get; set; }

        //relatie one to many : Role <-> UserRole
        public ICollection<Role> Roles { get; set; }


    }
}

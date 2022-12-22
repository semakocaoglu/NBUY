using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShoppingApp.Entity.Concrete.Identity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
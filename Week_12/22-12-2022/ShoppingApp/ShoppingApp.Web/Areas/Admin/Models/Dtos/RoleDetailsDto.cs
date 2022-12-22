using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Entity.Concrete.Identity;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class RoleDetailsDto
    {
        public Role Role { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }
    }
}
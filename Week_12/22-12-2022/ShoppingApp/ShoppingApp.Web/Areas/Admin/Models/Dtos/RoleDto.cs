using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; }

        [DisplayName("Rol Adı")]
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string Description { get; set; }
    }
}
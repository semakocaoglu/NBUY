using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class UserManageDto
    {

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alan zorunludur.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Cinsiyet")]

        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]

        public DateTime DateOfBirth { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alan zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DisplayName("Kullanıcı Ad")]
        [Required(ErrorMessage = "{0} alan zorunludur.")]
        public string UserName { get; set; }

        public List<SelectListItem> GenderSelectList { get; set; }

    }
}

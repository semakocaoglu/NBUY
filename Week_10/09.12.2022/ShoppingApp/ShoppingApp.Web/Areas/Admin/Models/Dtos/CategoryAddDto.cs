using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryAddDto
    {

        [DisplayName("KAtegori Ad")]
        [Required(ErrorMessage = "{0} adlı alan boş brakılmamalıdr")]
        [MinLength(5, ErrorMessage = "{0} en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} en az {1} karakterden uzun olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("KAtegori Açklaması")]
        [Required(ErrorMessage = "{0} adlı alan boş brakılmamalıdr")]
        [MinLength(5, ErrorMessage = "{0} en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(500, ErrorMessage = "{0} en az {1} karakterden uzun olmamalıdır.")]
        public string Description { get; set; }
    }
}

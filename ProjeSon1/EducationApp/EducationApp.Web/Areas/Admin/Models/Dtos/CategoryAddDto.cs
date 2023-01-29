using EducationApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Name { get; set; }


        //[DisplayName("Kategori Açıklaması")]
        //[Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        //[MinLength(10, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        //[MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        //public string Description { get; set; }

        //[DisplayName("Üst Kategorisi")]
        //[Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        //public int UpCatId { get; set; }

        public List<Category> UpCategories { get; set; }


    }
}


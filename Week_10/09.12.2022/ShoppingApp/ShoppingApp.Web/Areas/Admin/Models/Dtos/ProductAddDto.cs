using ShoppingApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class ProductAddDto
    {

        [DisplayName("Ürün Ad")]
        [Required(ErrorMessage = "{0} adlı alan boş brakılmamalıdr")]
        [MinLength(5, ErrorMessage = "{0} en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} en az {1} karakterden uzun olmamalıdır.")]
        public string  Name { get; set; }
        public decimal? Price { get; set; }

        [DisplayName("Ürün Ad")]
        [Required(ErrorMessage = "{0} adlı alan boş brakılmamalıdr")]
        [MinLength(5, ErrorMessage = "{0} en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(500, ErrorMessage = "{0} en az {1} karakterden uzun olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ürün Ad")]
        [Required(ErrorMessage = "{0} seçilmelidir")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Anasayfa Ürünü mü?")]
        public bool IsHome { get; set; }

        [DisplayName("Onayl mı?")]
        public bool IsApproved { get; set; }

        [DisplayName("Kategoriler")]
        public List<Category>Categories{ get; set; }

        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        public List<Category> SelectedCategories { get; set; }



    }
}

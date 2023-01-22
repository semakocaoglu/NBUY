using EducationApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EducationApp.Web.Areas.Admin.Models.Dtos
{
    public class TeacherAddDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Yaş")]
        public int Age { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Gender { get; set; }

        [DisplayName("Profil Fotoğrafı")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public string City { get; set; }

        [DisplayName("Hakkımda")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ders Verme Şekli")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public string LessonPlace { get; set; }

        [DisplayName("Eğitim Durumu")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string EducationStatus { get; set; }

        [DisplayName("Deneyim")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Experience { get; set; }

        [DisplayName("SAatlik Ders Ücreti")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public decimal? Price { get; set; }

        [DisplayName("Kategoriler")]
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        public int[] SelectedCategoryIds { get; set; }

        public string UserId { get; set; }
    }
}

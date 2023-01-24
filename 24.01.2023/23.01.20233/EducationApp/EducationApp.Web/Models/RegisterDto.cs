using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EducationApp.Entity.Concrete;

namespace EducationApp.Web.Models
{
    public class RegisterDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola ile {0} aynı olmalıdır.")]
        public string RePassword { get; set; }

        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        [DisplayName("Dersler")]
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "En az bir ders seçilmelidir.")]
        public int[] SelectedCategoryIds { get; set; }


    }
}

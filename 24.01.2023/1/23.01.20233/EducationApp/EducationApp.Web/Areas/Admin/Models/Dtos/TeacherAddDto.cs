using EducationApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EducationApp.Web.Areas.Admin.Models.Dtos
{
    public class TeacherAddDto
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

       

        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int Age { get; set; }


        [DisplayName("Dersler")]
        public List<Category> Categories { get; set; }


        [Required(ErrorMessage = "En az bir ders seçilmelidir.")]
        public int[] SelectedCategoryIds { get; set; }


        public string ImageUrl { get; set; }


        [DisplayName("Profil Resmi")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public IFormFile ImageFile { get; set; }

    }
}

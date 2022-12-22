using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class OrderDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        public string FirstName { get; set; }


        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string LastName { get; set; }


        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Address { get; set; }


        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Kartın Üzerindeki Ad Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarih")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }
        public CardDto CardDto { get; set; }
    }
}

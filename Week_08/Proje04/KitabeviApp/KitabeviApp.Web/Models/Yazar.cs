

namespace KitabeviApp.Web.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        
        public string Ad { get; set; }
        
        public int? DogumYili { get; set; }
        public char Cinsiyet { get; set; }
    }
}


//  [Required(ErrorMessage ="Lütfen adı boş bırakmayınız!")] //Zorunlu,
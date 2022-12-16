using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    //Uygulama içerisnde çeşitli durumlarda ihtiyaç duyacağız/ duyduğumuz uyarı mesajları için kullanılacak bir tip.
    public class AlertMessage
    {
        public string Title { get; set; } //Uyar mesajının başlığı
        public string Message { get; set; }//Uyar mesajı
        public string AlertType { get; set; }//Uyarı mesajnın tipi
    }
}






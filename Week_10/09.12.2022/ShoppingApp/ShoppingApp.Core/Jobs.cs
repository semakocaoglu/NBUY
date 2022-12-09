using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    public static class Jobs
    {
        public static string InitUrl(string url)
        {
            //Bu method kendisine gelen url değişkeninin içindeki 
            //1)Latin alfabesine çevrilirken problem çıkaran İ-i, ı-i gibi dönüştürmeleri yapacak.
            //2)  Diğer Türkçe karakterlerin yerine latin alfabesindeki karşılıklarını koyacak.
            //3)Boşluklar yerine - koyacak
            //4)Nokta(.) slash(/) gibi karakterleri kaldıracak.

            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");

            url = url.ToLower();
            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ş", "s");
            url = url.Replace("ç", "c");
            url = url.Replace("ğ", "g");

            url = url.Replace(" ", "-");
            url = url.Replace(".", "");
            url = url.Replace("/", "");
            url = url.Replace("(", "");
            url = url.Replace(")", "");
            url = url.Replace("ö", "o");
           

            return (url);





        }
    }
}

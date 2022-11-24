using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Data.EfCore.Abstract;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Concrete
{
    public class EfCoreYazarRepository : IYazarRepository
    {
        public List<Yazar> YazarListesi()
        {
            using (var context = new KitabeviContext())
            {
                List<Yazar> sonuc= context.Yazarlar.ToList();
                return sonuc;
            }
        }
    }
}
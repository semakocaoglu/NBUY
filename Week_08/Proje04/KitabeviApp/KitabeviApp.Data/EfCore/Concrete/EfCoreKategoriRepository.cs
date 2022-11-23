using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Data.EfCore.Abstract;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Concrete
{
    public class EfCoreKategoriRepository : IKategoriRepository
    {
        public void KategoriEkle(Kategori kategori)
        {
            using (var context = new KitabeviContext())
            {
                context.Kategoriler.Add(kategori);
                context.SaveChanges();
            }
        }

        public void KategoriGuncelle(Kategori kategori)
        {
            using (var context = new KitabeviContext())
            {
                context.Update(kategori);
                context.SaveChanges();
            }
        }


        public List<Kategori>KategoriListele()
        {
        using (var context = new KitabeviContext())
        {
            return context.Kategoriler.ToList();
        }
        }

        Kategori IKategoriRepository.KategoriGetir(int id)
        {
            using (var context = new KitabeviContext())
            {
                
                context.SaveChanges();
            }
        }
    }
}
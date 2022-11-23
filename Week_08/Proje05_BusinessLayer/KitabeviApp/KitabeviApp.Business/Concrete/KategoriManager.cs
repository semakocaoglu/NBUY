using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Business.Abstract;
using KitabeviApp.Data.EfCore.Concrete;

namespace KitabeviApp.Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        public void KategoriEkle(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public Kategori KategoriGetir(int id)
        {
            throw new NotImplementedException();
        }

        public void KategoriGuncelle(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> KategoriListele()
        {
            var kategoriRepository = new EfCoreKategoriRepository();
            return kategoriRepository.KategoriListele();
        }
    }
}
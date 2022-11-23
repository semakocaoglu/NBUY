using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace KitabeviApp.Business.Abstract
{
    public interface IKategoriService
    {
       
    
        List<Kategori>KategoriListele();

        void KategoriEkle(Kategori kategori);
        void KategoriGuncelle(Kategori kategori);

        Kategori KategoriGetir(int id);
    
    }
}
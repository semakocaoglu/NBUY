using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Entity;

namespace KitabeviApp.Data.EfCore.Abstract
{
    public interface IKitapRepository :  IGenericRepository<Kitap>
    {
        //Þuan burada IGenericRepositoryden gelen kitap için hazýrlanmýþ crud yazðýlarý var.
        //Eðer bir class IKitapRepositoryden miras alýrsa, tüm bu CRUD metotlarý da oraya implemente edilir.
        //Buraya ayrca yazýlacak metotlar(aþaðýdaki gibi) sadece kitap entitysine özgü metotlardýr.
        List<Kitap> KategoriyeGoreKitapListesi(int id);
    }
}
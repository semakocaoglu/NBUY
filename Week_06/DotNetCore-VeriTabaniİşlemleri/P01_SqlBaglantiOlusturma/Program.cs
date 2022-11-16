using System.Data.SqlClient;

namespace P01_SqlBaglantiOlusturma;

class Program
{
    static void Main(string[] args)
    {
        GetSqlConnection();
        
    }
    static void GetSqlConnection()
    {
        /* 1.Adım
            ConnectionString oluşturmak
        */
        string connectionString = @"Server=DESKTOP-OFVK2FD\SQLEXPRESS;Database=Northwind; User Id=sa; Password=123";


        using (var connection = new SqlConnection(connectionString))
        {
            //connection nesnesi sadece bu scope içinde yaşayıp, scope bitişinde bellekten kaldırılmış olacak!
            try
            {
                connection.Open();
                Console.WriteLine("Bağlantı sağlandı...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

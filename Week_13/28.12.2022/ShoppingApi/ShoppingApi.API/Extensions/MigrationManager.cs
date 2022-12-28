using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Concrete.EfCore.Contexts;

namespace ShoppingApi.API.Extensions
{
    public static class MigrationManager
    {
        public static IHost UpdateDatabase(this IHost host) 
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var shopAppContext = scope.ServiceProvider.GetRequiredService<ShopAppContext>())
                {
                    try
                    {
                        shopAppContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
            return host;
        }
    }
}

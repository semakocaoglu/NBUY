namespace ShoppingApp.Web.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; } // hangi propertyleri göstermek istiyorsam onları alıyorum
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }



    }
}

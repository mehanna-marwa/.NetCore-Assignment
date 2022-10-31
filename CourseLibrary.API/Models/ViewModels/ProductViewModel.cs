namespace Products.API.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public string  CategoryName { get; set; }

    }
}

namespace Products.API.Models.ActionModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public int CategoryId { get; set; }
    }
}

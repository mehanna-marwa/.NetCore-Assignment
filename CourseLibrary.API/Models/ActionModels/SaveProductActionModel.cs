namespace Products.API.Models.ActionModels
{
    public class SaveProductActionModel
    {
        public string Name { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public int CategoryId { get; set; }
    }
}

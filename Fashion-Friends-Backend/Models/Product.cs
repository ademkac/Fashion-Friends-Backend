namespace Fashion_Friends_Backend.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ImageOfProduct>? Picture { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public List<SizeOfProduct>? Size { get; set; }
        public List<ColorOfProduct>? Color { get; set; }
        public string ArticleCode { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string MainCategory { get; set; } = string.Empty;
    }
}

namespace Demo.DesignPattern.Command.Models
{
    public class Product
    {
        public string ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product()
        {

        }

        public Product(string articleId, string name, decimal price)
        {
            this.ArticleId = articleId;
            this.Name = name;
            this.Price = price;
        }
    }
}

namespace Demo.DesignPattern.Command.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Demo.DesignPattern.Command.Models;

    /// <summary>
    /// The products repository.
    /// </summary>
    public class ProductsRepository : IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        public ProductsRepository()
        {
            this.Products = new Dictionary<string, (Product Product, int Stock)>();

            this.Add(new Product("P001", "Product One", 100), 1);
            this.Add(new Product("P002", "Product Two", 200), 2);
            this.Add(new Product("P003", "Product Three", 300), 3);
            this.Add(new Product("P004", "Product Four", 400), 4);
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        private Dictionary<string, (Product Product, int Stock)> Products { get; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <param name="stock">
        /// The stock.
        /// </param>
        public void Add(Product product, int stock)
        {
            this.Products[product.ArticleId] = (product, stock);
        }

        /// <summary>
        /// The all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<Product> All()
        {
            return this.Products.Select(x => x.Value.Product);
        }

        /// <summary>
        /// The decrease stock by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public void DecreaseStockBy(string articleId, int amount)
        {
            if (!this.Products.ContainsKey(articleId))
            {
                return;
            }

            this.Products[articleId] = (this.Products[articleId].Product, this.Products[articleId].Stock - amount);
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        public Product FindBy(string articleId)
        {
            if (this.Products.ContainsKey(articleId))
            {
                return this.Products[articleId].Product;
            }

            return null;
        }

        /// <summary>
        /// The get stock for.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetStockFor(string articleId)
        {
            if (this.Products.ContainsKey(articleId))
            {
                return this.Products[articleId].Stock;
            }

            return 0;
        }

        /// <summary>
        /// The increase stock by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public void IncreaseStockBy(string articleId, int amount)
        {
            if (!this.Products.ContainsKey(articleId))
            {
                return;
            }

            this.Products[articleId] = (this.Products[articleId].Product, this.Products[articleId].Stock + amount);
        }
    }
}
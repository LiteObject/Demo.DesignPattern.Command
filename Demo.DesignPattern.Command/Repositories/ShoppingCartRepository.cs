namespace Demo.DesignPattern.Command.Repositories
{
    using System;
    using System.Collections.Generic;

    using Demo.DesignPattern.Command.Models;

    /// <summary>
    /// The shopping cart repository.
    /// </summary>
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        /// <summary>
        /// The line items.
        /// </summary>
        private readonly Dictionary<string, (Product Product, int Quantity)> lineItems = 
            new Dictionary<string, (Product Product, int Quantity)>();

        /// <summary>
        /// The all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<(Product Product, int Quantity)> All()
        {
            return this.lineItems.Values;
        }

        /// <inheritdoc/>
        public (Product Product, int Quantity) Get(string articleId)
        {
            if (this.lineItems.ContainsKey(articleId))
            {
                return this.lineItems[articleId];
            }

            return (default, default);
        }

        /// <inheritdoc/>
        public void Add(Product product)
        {
            if (this.lineItems.ContainsKey(product.ArticleId))
            {
                this.IncreaseQuantity(product.ArticleId);
            }
            else
            {
                this.lineItems[product.ArticleId] = (product, 1);
            }
        }

        /// <inheritdoc/>
        public void DecreaseQuantity(string articleId)
        {
            if (this.lineItems.ContainsKey(articleId))
            {
                var lineItem = this.lineItems[articleId];

                if (lineItem.Quantity == 1)
                {
                    this.lineItems.Remove(articleId);
                }
                else
                {
                    this.lineItems[articleId] = (lineItem.Product, lineItem.Quantity - 1);
                }
            }
            else
            {
                throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
            }
        }

        /// <inheritdoc/>
        public void IncreaseQuantity(string articleId)
        {
            if (this.lineItems.ContainsKey(articleId))
            {
                var lineItem = this.lineItems[articleId];
                this.lineItems[articleId] = (lineItem.Product, lineItem.Quantity + 1);
            }
            else
            {
                throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
            }
        }

        /// <inheritdoc/>
        public void RemoveAll(string articleId)
        {
            this.lineItems.Remove(articleId);
        }
    }
}

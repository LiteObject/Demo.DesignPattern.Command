namespace Demo.DesignPattern.Command.Repositories
{
    using System.Collections.Generic;

    using Demo.DesignPattern.Command.Models;

    /// <summary>
    /// The ProductRepository interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// The all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<Product> All();

        /// <summary>
        /// The decrease stock by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        void DecreaseStockBy(string articleId, int amount);

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        Product FindBy(string articleId);

        /// <summary>
        /// The get stock for.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetStockFor(string articleId);

        /// <summary>
        /// The increase stock by.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        void IncreaseStockBy(string articleId, int amount);
    }
}
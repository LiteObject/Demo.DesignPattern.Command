namespace Demo.DesignPattern.Command.Repositories
{
    using System;
    using System.Collections.Generic;

    using Demo.DesignPattern.Command.Models;

    /// <summary>
    ///     The ShoppingCartRepository interface.
    /// </summary>
    public interface IShoppingCartRepository
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void Add(Product product);

        /// <summary>
        /// The all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<(Product Product, int Quantity)> All();

        /// <summary>
        /// The decrease quantity.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        void DecreaseQuantity(string articleId);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple{T1,T2}"/>.
        /// </returns>
        (Product Product, int Quantity) Get(string articleId);

        /// <summary>
        /// The increase quantity.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        void IncreaseQuantity(string articleId);

        /// <summary>
        /// The remove all.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        void RemoveAll(string articleId);
    }
}
namespace Demo.DesignPattern.Command.Commands
{
    using System;

    using Demo.DesignPattern.Command.Models;
    using Demo.DesignPattern.Command.Repositories;

    /// <inheritdoc />
    public class RemoveFromCartCommand : ICommand
    {
        /// <summary>
        /// The product.
        /// </summary>
        private readonly Product product;

        /// <summary>
        /// The product repository.
        /// </summary>
        private readonly IProductRepository productRepository;

        /// <summary>
        /// The shopping cart repository.
        /// </summary>
        private readonly IShoppingCartRepository shoppingCartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveFromCartCommand"/> class.
        /// </summary>
        /// <param name="shoppingCartRepository">
        /// The shopping cart repository.
        /// </param>
        /// <param name="productRepository">
        /// The product repository.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        public RemoveFromCartCommand(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        /// <inheritdoc />
        public bool CanExecute()
        {
            if (this.product == null)
            {
                return false;
            }

            return this.shoppingCartRepository.Get(this.product.ArticleId).Quantity > 0;
        }

        /// <inheritdoc />
        public void Execute()
        {
            if (this.product == null)
            {
                return;
            }

            var lineItem = this.shoppingCartRepository.Get(this.product.ArticleId);

            this.productRepository.IncreaseStockBy(this.product.ArticleId, lineItem.Quantity);

            this.shoppingCartRepository.RemoveAll(this.product.ArticleId);
        }

        /// <inheritdoc />
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Demo.DesignPattern.Command.Commands
{
    using System;
    using System.Linq;

    using Demo.DesignPattern.Command.Repositories;

    /// <inheritdoc />
    public class RemoveAllFromCartCommand : ICommand
    {
        /// <summary>
        /// The product repository.
        /// </summary>
        private readonly IProductRepository productRepository;

        /// <summary>
        /// The shopping cart repository.
        /// </summary>
        private readonly IShoppingCartRepository shoppingCartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAllFromCartCommand"/> class.
        /// </summary>
        /// <param name="shoppingCartRepository">
        /// The shopping cart repository.
        /// </param>
        /// <param name="productRepository">
        /// The product repository.
        /// </param>
        public RemoveAllFromCartCommand(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        /// <inheritdoc />
        public bool CanExecute()
        {
            return this.shoppingCartRepository.All().Any();
        }

        /// <inheritdoc />
        public void Execute()
        {
            var items = this.shoppingCartRepository.All().ToArray(); // Make a local copy

            foreach (var lineItem in items)
            {
                this.productRepository.IncreaseStockBy(lineItem.Product.ArticleId, lineItem.Quantity);

                this.shoppingCartRepository.RemoveAll(lineItem.Product.ArticleId);
            }
        }

        /// <inheritdoc />
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
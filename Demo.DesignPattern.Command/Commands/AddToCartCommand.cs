namespace Demo.DesignPattern.Command.Commands
{
    using Demo.DesignPattern.Command.Models;
    using Demo.DesignPattern.Command.Repositories;

    /// <summary>
    ///     The add to cart command.
    /// </summary>
    internal class AddToCartCommand : ICommand
    {
        /// <summary>
        ///     The product.
        /// </summary>
        private readonly Product product;

        /// <summary>
        ///     The product repository.
        /// </summary>
        private readonly IProductRepository productRepository;

        /// <summary>
        ///     The shopping cart repository.
        /// </summary>
        private readonly IShoppingCartRepository shoppingCartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddToCartCommand"/> class.
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
        public AddToCartCommand(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        /// <summary>
        ///     The can execute.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool CanExecute()
        {
            if (this.product == null)
            {
                return false;
            }

            return this.productRepository.GetStockFor(this.product.ArticleId) > 0;
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        public void Execute()
        {
            if (this.product == null)
            {
                return;
            }

            this.productRepository.DecreaseStockBy(this.product.ArticleId, 1);
            this.shoppingCartRepository.Add(this.product);
        }

        /// <summary>
        ///     The undo.
        /// </summary>
        public void Undo()
        {
            if (this.product == null)
            {
                return;
            }

            var lineItem = this.shoppingCartRepository.Get(this.product.ArticleId);

            this.productRepository.IncreaseStockBy(this.product.ArticleId, lineItem.Quantity);

            this.shoppingCartRepository.RemoveAll(this.product.ArticleId);
        }
    }
}
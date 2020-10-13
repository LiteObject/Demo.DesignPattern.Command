namespace Demo.DesignPattern.Command.Commands
{
    using Demo.DesignPattern.Command.Models;
    using Demo.DesignPattern.Command.Repositories;

    /// <inheritdoc />
    public class ChangeQuantityCommand : ICommand
    {
        /// <summary>
        /// The operation.
        /// </summary>
        private readonly Operation operation;

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
        /// Initializes a new instance of the <see cref="ChangeQuantityCommand"/> class.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="shoppingCartRepository">
        /// The shopping cart repository.
        /// </param>
        /// <param name="productRepository">
        /// The product repository.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        public ChangeQuantityCommand(
            Operation operation,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.operation = operation;
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        /// <summary>
        /// The operation.
        /// </summary>
        public enum Operation
        {
            /// <summary>
            /// The increase.
            /// </summary>
            Increase,

            /// <summary>
            /// The decrease.
            /// </summary>
            Decrease
        }

        /// <inheritdoc />
        public bool CanExecute()
        {
            switch (this.operation)
            {
                case Operation.Decrease:
                    return this.shoppingCartRepository.Get(this.product.ArticleId).Quantity != 0;
                case Operation.Increase:
                    return this.productRepository.GetStockFor(this.product.ArticleId) - 1 >= 0;
            }

            return false;
        }

        /// <inheritdoc />
        public void Execute()
        {
            switch (this.operation)
            {
                case Operation.Decrease:
                    this.productRepository.IncreaseStockBy(this.product.ArticleId, 1);
                    this.shoppingCartRepository.DecreaseQuantity(this.product.ArticleId);
                    break;
                case Operation.Increase:
                    this.productRepository.DecreaseStockBy(this.product.ArticleId, 1);
                    this.shoppingCartRepository.IncreaseQuantity(this.product.ArticleId);
                    break;
            }
        }

        /// <inheritdoc />
        public void Undo()
        {
            switch (this.operation)
            {
                case Operation.Decrease:
                    this.productRepository.DecreaseStockBy(this.product.ArticleId, 1);
                    this.shoppingCartRepository.IncreaseQuantity(this.product.ArticleId);
                    break;
                case Operation.Increase:
                    this.productRepository.IncreaseStockBy(this.product.ArticleId, 1);
                    this.shoppingCartRepository.DecreaseQuantity(this.product.ArticleId);
                    break;
            }
        }
    }
}
namespace Demo.DesignPattern.Command
{
    using System;

    using Demo.DesignPattern.Command.Commands;
    using Demo.DesignPattern.Command.Repositories;

    /// <summary>
    /// The program.
    /// This demo is based on "https://app.pluralsight.com/library/courses/c-sharp-command-pattern/description"
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var shoppingCartRepo = new ShoppingCartRepository();
            var productRepository = new ProductsRepository();

            var product = productRepository.FindBy("P004");

            var addToCartCommand = new AddToCartCommand(shoppingCartRepo, productRepository, product);
            var increaseQuantityCommand = new ChangeQuantityCommand(
                ChangeQuantityCommand.Operation.Increase,
                shoppingCartRepo, 
                productRepository,
                product);

            var manager = new CommandManager();
            manager.Invoke(addToCartCommand);
            manager.Invoke(increaseQuantityCommand);

            // manager.Undo();
        }
    }
}

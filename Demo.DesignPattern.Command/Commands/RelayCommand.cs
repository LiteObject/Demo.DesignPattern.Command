namespace Demo.DesignPattern.Command.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;

    /// <inheritdoc />
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        private readonly Action execute;

        /// <summary>
        /// The can execute.
        /// </summary>
        private readonly Func<bool> canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <inheritdoc />
        public void Execute()
        {
            this.execute?.Invoke();
        }

        /// <inheritdoc />
        public bool CanExecute()
        {
            return this.canExecute?.Invoke() ?? false;
        }

        /// <inheritdoc />
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}

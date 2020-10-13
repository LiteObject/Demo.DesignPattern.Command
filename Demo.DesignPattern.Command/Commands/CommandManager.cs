namespace Demo.DesignPattern.Command.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// The command manager.
    /// </summary>
    internal class CommandManager
    {
        /// <summary>
        /// The commands.
        /// </summary>
        private readonly Stack<ICommand> commands = new Stack<ICommand>();

        /// <summary>
        /// The invoke.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                this.commands.Push(command);
            }
        }

        /// <summary>
        /// The undo.
        /// </summary>
        public void Undo()
        {
            while (this.commands.Count > 0)
            {
                ICommand command = this.commands.Pop();
                command.Undo();
            }
        }
    }
}
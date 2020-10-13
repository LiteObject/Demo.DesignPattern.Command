namespace Demo.DesignPattern.Command.Commands
{
    using System;

    /// <summary>
    /// The Command interface. This is very similar to "System.Windows.Input.ICommand" interface.
    /// </summary>
    public interface ICommand
    {
        /*// <summary>
        /// The can execute changed. This may not be needed in our web app.
        /// </summary>
        event EventHandler CanExecuteChanged; */

        /// <summary>
        /// The execute.
        /// </summary>
        void Execute();

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CanExecute();

        /// <summary>
        /// The undo.
        /// </summary>
        void Undo();
    }
}

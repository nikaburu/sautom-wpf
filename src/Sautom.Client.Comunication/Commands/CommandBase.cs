using System;
using System.Windows.Input;

namespace Sautom.Client.Comunication.Commands
{
    public abstract class CommandBase : ICommand
    {
        #region Implementation of ICommand

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        public void RaiseCanExecuteChanged()
        {
	        CanExecuteChanged?.Invoke(this, new EventArgs());
        }

	    #region

	    protected abstract void Execute();

	    protected virtual bool CanExecute()
        {
            return true;
        }

        #endregion
    }
}

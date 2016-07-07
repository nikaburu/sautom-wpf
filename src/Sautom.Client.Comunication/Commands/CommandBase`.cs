using System;
using System.Windows.Input;

namespace Sautom.Client.Comunication.Commands
{
    public abstract class CommandBase<T> : ICommand
    {
        #region Implementation of ICommand

        void ICommand.Execute(object parameter)
        {
            if (parameter is T)
            {
                Execute((T)parameter);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (parameter is T)
            {
                return CanExecute((T)parameter);
            }

            return true;
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        #region

	    protected abstract void Execute(T parameter);

	    protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        #endregion
    }
}

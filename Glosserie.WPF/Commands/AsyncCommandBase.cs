using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private readonly Action<Exception> _onException;

        public event EventHandler CanExecuteChanged;


        public AsyncCommandBase(Action<Exception> onException)
        {
            _onException = onException;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);                
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExcecuting;

        public bool IsExcecuting
        {
            get { return _isExcecuting; }
            set 
            {
                _isExcecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }


        private readonly Action<Exception> _onException;

        public event EventHandler CanExecuteChanged;


        public AsyncCommandBase(Action<Exception> onException)
        {
            _onException = onException;
        }

        public bool CanExecute(object parameter)
        {
            return !IsExcecuting;
        }

        public async void Execute(object parameter)
        {
            IsExcecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);                
            }
            IsExcecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}

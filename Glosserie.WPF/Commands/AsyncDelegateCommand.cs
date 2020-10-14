using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Commands
{
    public class AsyncDelegateCommand : AsyncCommandBase
    {

        private readonly Func<Task> _callBack;

        public AsyncDelegateCommand(Func<Task> callBack, Action<Exception> onException) : base(onException)
        {
            _callBack = callBack;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _callBack();
        }
    }
}

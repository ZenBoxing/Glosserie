using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Commands
{
    public class DelegateCommand : CommandBase
    {
        private readonly Action _callBack;

        public DelegateCommand(Action callBack)
        {
            _callBack = callBack;
        }

        public override void Execute(object parameter)
        {
            _callBack();
        }
    }
}

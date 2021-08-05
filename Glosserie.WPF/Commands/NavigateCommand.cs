using Glosserie.WPF.Services;
using Glosserie.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Commands
{
    public class NavigateCommand : CommandBase 
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
           _navigationService.Navigate();
        }
    }
}

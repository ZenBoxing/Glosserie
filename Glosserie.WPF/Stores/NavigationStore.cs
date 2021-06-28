using Glosserie.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Stores
{
    public class NavigationStore : INavigationStore
    {
        public ViewModelBase ActiveViewModel { get; set; }
    }
}

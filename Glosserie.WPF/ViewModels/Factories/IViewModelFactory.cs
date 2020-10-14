using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}

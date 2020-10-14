using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}

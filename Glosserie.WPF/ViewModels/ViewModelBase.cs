using Glosserie.WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels
{
    public enum TViewModel
    {
        Home,
        Login,
        Register,
        VocabLists
    }

    public class ViewModelBase : ObservableObject
    {
        public virtual void Dispose() { }   
    }


}

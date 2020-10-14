using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public VocabListsViewModel VocabListsViewModel { get; set; }

        public string Test { get; set; } = "Testing Hello";


        public HomeViewModel(VocabListsViewModel vocabListsViewModel)
        {
            VocabListsViewModel = vocabListsViewModel;
        }

	}
}

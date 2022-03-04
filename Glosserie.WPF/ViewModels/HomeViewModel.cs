using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public VocabListsViewModel VocabListsViewModel { get; set; }
        public CreateVocabListFormViewModel CreateVocabListFormViewModel { get; set; }

        

        public HomeViewModel(VocabListsViewModel vocabListsViewModel, CreateVocabListFormViewModel createVocabListFormViewModel)
        {
            
            VocabListsViewModel = vocabListsViewModel;
            CreateVocabListFormViewModel = createVocabListFormViewModel;
            
        }

       
    }
}

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

        private bool _isCreateListModalOpen;
        public bool IsCreateListModalOpen
        {
            get
            {
                return _isCreateListModalOpen;
            }
            set
            {
                _isCreateListModalOpen = value;
                OnPropertyChanged(nameof(IsCreateListModalOpen));
            }
        }

        public ICommand OpenCreateListModalCommand { get; }
        public ICommand CloseCreateListModalCommand { get; }

        public HomeViewModel(VocabListsViewModel vocabListsViewModel)
        {
            VocabListsViewModel = vocabListsViewModel;

            OpenCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = true);
            CloseCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = false);
        }

	}
}

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

        public VocabListOptionsModel VocabListOptionsModel { get; set; }

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

        private string _ListName;
        public string ListName
        {
            get
            {
                return _ListName;
            }
            set
            {
                _ListName = value;
                OnPropertyChanged(nameof(ListName));
            }
        }

        private int[] _ListLengthOptions;

        public int[] ListLengthOptions
        {
            get { return _ListLengthOptions; }
            set { _ListLengthOptions = value; }
        } 


        private int _selectedListLengthOption;
        public int SelectedListLengthOption
        {
            get
            {
                return _selectedListLengthOption;
            }
            set
            {
                _selectedListLengthOption = value;
                OnPropertyChanged(nameof(SelectedListLengthOption));
            }
        }

        public ICommand OpenCreateListModalCommand { get; }
        public ICommand CloseCreateListModalCommand { get; }
        public ICommand OpenFileDialogBoxCommand { get; }

        public HomeViewModel(VocabListsViewModel vocabListsViewModel)
        {
            LoadListLengthOptions();
            VocabListsViewModel = vocabListsViewModel;
            VocabListOptionsModel = new VocabListOptionsModel();

            OpenCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = true);
            CloseCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = false);
            OpenFileDialogBoxCommand = new DelegateCommand(OpenFileDialogBox);
        }

        public void OpenFileDialogBox()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)| *.pdf";
            if(openFileDialog.ShowDialog() == true)
            {
                VocabListOptionsModel.FileContents = File.ReadAllBytes(openFileDialog.FileName);
            }
            //openFileDialog.ShowDialog();
        }

        public void LoadListLengthOptions()
        { 
            ListLengthOptions = new int[]{ 10, 15, 25, 50 };
        }
	}
}

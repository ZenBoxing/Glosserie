using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Stores;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class CreateVocabListFormViewModel : ViewModelBase
    {
        public string StatusMessage;

        private readonly VocabListStore _vocabListStore;

        private readonly IAuthenticator _authenticator;
        private readonly IVocabListService _vocabListService;

        public bool IsFileValid => FileContents != null;

        private bool _isCreateListSuccessful;
        public bool IsCreateListSuccessful
        {
            get
            {
                return _isCreateListSuccessful;
            }
            set
            {
                _isCreateListSuccessful = value;
                OnPropertyChanged(nameof(IsCreateListSuccessful));
            }
        }

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

        private string _listName;
        public string ListName
        {
            get
            {
                return _listName;
            }
            set
            {
                _listName = value;
                OnPropertyChanged(nameof(ListName));
            }
        }

        private int[] _listLengthOptions;

        public int[] ListLengthOptions
        {
            get { return _listLengthOptions; }
            set { _listLengthOptions = value; }
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

        private byte[] _fileContents;
        public byte[] FileContents
        {
            get
            {
                return _fileContents;
            }
            set
            {
                _fileContents = value;
                OnPropertyChanged(nameof(FileContents));
                OnPropertyChanged(nameof(IsFileValid));
            }
        }

        public ICommand OpenCreateListModalCommand { get; }
        public ICommand CloseCreateListModalCommand { get; }
        public ICommand OpenFileDialogBoxCommand { get; }
        public ICommand CreateVocabListCommand { get; }

        public CreateVocabListFormViewModel(IVocabListService vocabListService, IAuthenticator authenticator, VocabListStore vocabListStore)
        {
            LoadListLengthOptions();
            _vocabListService = vocabListService;
            _authenticator = authenticator;

            OpenCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = true);
            CloseCreateListModalCommand = new DelegateCommand(() => IsCreateListModalOpen = false);
            CreateVocabListCommand = new AsyncDelegateCommand(CreateVocabList, (ex) => StatusMessage = ex.Message);

            OpenFileDialogBoxCommand = new DelegateCommand(OpenFileDialogBox);
            _vocabListStore = vocabListStore;
        }

        public void OpenFileDialogBox()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)| *.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
               FileContents = File.ReadAllBytes(openFileDialog.FileName);
            }
            //openFileDialog.ShowDialog();
        }

        public void LoadListLengthOptions()
        {
            ListLengthOptions = new int[] { 10, 15, 25, 50 };
        }

        public async Task CreateVocabList()
        {
            VocabListOptionsModel options = new VocabListOptionsModel
            {
                UserId = _authenticator.CurrentUser.UserID,
                FileContents = _fileContents,
                Length = _selectedListLengthOption,
                ListName = _listName
            };
            IsCreateListSuccessful = await _vocabListService.GetCreateVocabList(options);
            if (IsCreateListSuccessful) await _vocabListStore.LoadVocabListsAsync();
        }
    }
}

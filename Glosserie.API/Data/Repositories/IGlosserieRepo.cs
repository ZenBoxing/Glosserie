using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data
{
    public interface IGlosserieRepo
    {
        IEnumerable<VocabListModel> GetVocabLists();
        IEnumerable<VocabListModel> GetVocabListsByUser(int userId);
        IEnumerable<VocabListModel> GetVocabListsById(int listId);
        IEnumerable<EntryModel> GetEntriesByList(int vocabListId);
        IEnumerable<EntryModel> GetAllEntries();
        UserModel getUser(int userId);
        void CreateVocabList(VocabListOptionsModel options);
        bool CreateVocabList(); // remove parameterless method after testing
    }
}

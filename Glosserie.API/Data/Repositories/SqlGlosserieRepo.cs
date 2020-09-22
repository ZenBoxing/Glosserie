using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data.Repositories
{
    public class SqlGlosserieRepo : IGlosserieRepo
    {
        public void CreateVocabList(List<EntryModel> wordList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntryModel> GetAllEntries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntryModel> GetEntriesByList(int vocabListId)
        {
            throw new NotImplementedException();
        }

        public UserModel getUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VocabListModel> GetVocabLists()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VocabListModel> GetVocabListsById(int listId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VocabListModel> GetVocabListsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

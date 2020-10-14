using Glosserie.API.Data.DataAccess;
using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data.Repositories
{
    public class SqlGlosserieRepo : IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public SqlGlosserieRepo(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }


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
            var records = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                ("ListeraDB.listeradb.spGetVocabLists", new { }, "GlosserieSSAuth");

            return records;
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

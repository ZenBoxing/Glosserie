using Glosserie.API.Data.DataAccess;
using Glosserie.API.Models;
using Glosserie.API.Utility;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data
{
    public class MockGLosserieRep : IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public MockGLosserieRep(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public bool CreateVocabList()
        {
            bool success = false;
            //create VocabListModel
            VocabListInsertModel vocabListInsertModel = new VocabListInsertModel
            {
                ListName = "TestData",
                UserId = 1
            };
            //check if listname already exists for this user

            try
            {
                _sqlDataAccess.SaveData<VocabListInsertModel>("ListeraDB.listeradb.spInsertVocabList", vocabListInsertModel, "GlosserieSSAuth");
                success = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string trace = ex.StackTrace;
            }

            return success;

        }

        public void CreateVocabList(VocabListOptionsModel options)
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
            return new UserModel { UserID = 0, Email = "email@email.com", Password = "password" };
        }

        public IEnumerable<VocabListModel> GetVocabLists()
        {
            var vocabLists = new List<VocabListModel>
            {
                new VocabListModel{
                    ListId = 1,
                    ListName = "Madame Bovary Vocab",
                    UserId = 0
                },
                new VocabListModel{
                    ListId = 2,
                    ListName = "Moby Dick Vocab",
                    UserId = 1
                },
                new VocabListModel{
                    ListId = 3,
                    ListName = "War & Peace Vocab",
                    UserId = 2
                }
            };

            return vocabLists;
        }

        public IEnumerable<VocabListModel> GetVocabListsById(int listId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VocabListModel> GetVocabListsByUser(int userId)
        {
            var vocabLists = new List<VocabListModel>
            {
                new VocabListModel{
                    ListId = 1,
                    ListName = "Madame Bovary Vocab",
                    UserId = 0
                },
                new VocabListModel{
                    ListId = 2,
                    ListName = "Moby Dick Vocab",
                    UserId = 1
                },
                new VocabListModel{
                    ListId = 3,
                    ListName = "War & Peace Vocab",
                    UserId = 2
                }
            };

            return vocabLists;
        }
    }
}

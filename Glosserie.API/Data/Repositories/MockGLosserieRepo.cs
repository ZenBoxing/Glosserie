using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data
{
    public class MockGLosserieRepo : IGlosserieRepo
    {
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

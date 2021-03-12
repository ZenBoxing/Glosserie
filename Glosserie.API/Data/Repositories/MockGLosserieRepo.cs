using Glosserie.API.Data.DataAccess;
using Glosserie.API.Models;
using Glosserie.API.Services;
using Glosserie.API.Utility;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data
{
    public class MockGLosserieRep : IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IAuthenticationService _authenticationService;

        public MockGLosserieRep(ISqlDataAccess sqlDataAccess, IAuthenticationService authenticationService)
        {
            _sqlDataAccess = sqlDataAccess;
            _authenticationService = authenticationService;
        }

        public bool CreateVocabList()
        {
            string path = "C:/Users/jarre/GlosserieApp/Glosserie/Glosserie.API/TestPDFs/Test_Sample.pdf";
            bool success = false;
            bool status = File.Exists(path);
            //create VocabListModel
            //VocabListInsertModel vocabListInsertModel = new VocabListInsertModel
            //{
            //    ListName = "TestData",
            //    UserId = 1
            //};
            //check if listname already exists for this user

            //perhaps use stringbuilder
            string ExtractedText = "";


            if (status)
            {

                try
                {
                    byte[] content = File.ReadAllBytes(path);
                    PdfLoadedDocument pdf = new PdfLoadedDocument(content);

                    foreach  (PdfPageBase page in pdf.Pages)
                    {
                        ExtractedText += page.ExtractText();
                    }

                    string[] wordArray = TextHandler.GetSeparatedWordArray(ExtractedText);

                    //create entry models from word list
                    List<EntryModel> entries = new List<EntryModel>();

                    foreach (var word in wordArray)
                    {
                        entries.Add(new EntryModel { Word = word });
                    }

                    //get entryID from database for each entrymodel
                    foreach (var entry in entries)
                    {
                        var records = _sqlDataAccess.LoadData<EntryModel, dynamic>
                        ("ListeraDB.listeradb.spGetEntryByWord", new { word = entry.Word }, "GlosserieSSAuth");

                        
                        if (records.Count > 0)
                        {
                            var record = records.Find(x => x.Word.ToLower() == entry.Word);
                            if (record.EntryID != 0)
                            {
                                entry.EntryID = record.EntryID;
                                entry.WordRank = record.WordRank;
                            }                      
                        }
                    }

                    //remove entries not found in dictionary
                    entries.RemoveAll(x => x.EntryID == 0);
                    //get 25 least common words by wordrank
                    List<EntryModel> sortedEntries = entries.OrderBy(x => x.WordRank).ToList();
                   
                    if (sortedEntries.Count > 25)
                    {
                        sortedEntries.RemoveRange(25, sortedEntries.Count - 25); 
                    }

                    //get listid from database
                    var listFromDB = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                        ("ListeraDB.listeradb.spGetListByListName", new { listname = "TestData", userID = 1 }, "GlosserieSSAuth");



                    //save sorted entries to database as list entries
                    foreach (var entry in sortedEntries)
                    {
                        _sqlDataAccess.SaveData<ListEntryModel>("ListeraDB.listeradb.spInsertListEntry", 
                            new ListEntryModel {ListID = listFromDB[0].ListId, EntryID = entry.EntryID }, "GlosserieSSAuth");
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    string trace = ex.StackTrace;
                } 
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

        public UserModel Login(string email, string password)
        {
            return _authenticationService.Login(email, password);
        }

        public bool Register(string email, string password, string confirmpassword)
        {
            return _authenticationService.Register(email,password,confirmpassword);
        }
    }
}

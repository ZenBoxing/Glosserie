using Glosserie.API.Data.DataAccess;
using Glosserie.API.Exceptions;
using Glosserie.API.Models;
using Glosserie.API.Services;
using Glosserie.API.Utility;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.API.Data.Repositories
{
    public class SqlGlosserieRepo : IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IAuthenticationService _authenticationService;

        public SqlGlosserieRepo(ISqlDataAccess sqlDataAccess, IAuthenticationService authenticationService)
        {
            _sqlDataAccess = sqlDataAccess;
            _authenticationService = authenticationService;
        }


        public bool CreateVocabList(VocabListOptionsModel options)
        {
            bool success = false;
            
            //create VocabListModel
            VocabListInsertModel vocabListModel = new VocabListInsertModel { ListName = options.ListName,
                                                                 UserId = options.UserId};
            //check if listname already exists for this user
            var listname = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                ("ListeraDB.listeradb.spGetListByName", new { UserId = vocabListModel.UserId, ListName = vocabListModel.ListName },
                "GlosserieSSAuth");

            if (listname.Count > 0) throw new ListNameAlreadyExistsException("List name already exist for this user",vocabListModel.ListName);
            
            //save VocabListModel to database (look into sql transactions)
            _sqlDataAccess.SaveData<VocabListInsertModel>("ListeraDB.listeradb.spInsertVocabList", vocabListModel, "GlosserieSSAuth");



            try
            {
                PdfLoadedDocument pdf = new PdfLoadedDocument(options.FileContents);
                string ExtractedText = "";
                
                foreach (PdfPageBase page in pdf.Pages)
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
                //get least common words by wordrank
                List<EntryModel> sortedEntries = entries.OrderBy(x => x.WordRank).ToList();

                if (sortedEntries.Count > options.Length)
                {
                    sortedEntries.RemoveRange(options.Length, sortedEntries.Count - options.Length);
                }

                //get listid from database
                var listFromDB = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                    ("ListeraDB.listeradb.spGetListByName", new { listname = options.ListName, userID = options.UserId }, "GlosserieSSAuth");



                //save sorted entries to database as list entries
                foreach (var entry in sortedEntries)
                {
                    _sqlDataAccess.SaveData<ListEntryModel>("ListeraDB.listeradb.spInsertListEntry",
                        new ListEntryModel { ListID = listFromDB[0].ListId, EntryID = entry.EntryID }, "GlosserieSSAuth");
                }
                success = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string trace = ex.StackTrace;

            }
            return success;

        }

        public bool DeleteList(int listID)
        {
            try
            {
                _sqlDataAccess.DeleteData
                        ("ListeraDB.listeradb.spDeleteListEntries", new { listID = listID }, "GlosserieSSAuth");

            }
            catch (Exception ex)
            {
                string m = ex.Message;
                string s = ex.StackTrace;
                return false;
            }
            //delete vocablist
            try
            {
                _sqlDataAccess.DeleteData
                        ("ListeraDB.listeradb.spDeleteVocabList", new { listID = listID }, "GlosserieSSAuth");

            }
            catch (Exception ex)
            {
                string m = ex.Message;
                string s = ex.StackTrace;
                return false;
            }
            return true;
        }

        public IEnumerable<EntryModel> GetEntriesByList(int userId, string listname)
        {
            try
            {
                //get listid from database
                var vocabList = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                    ("ListeraDB.listeradb.spGetListByName", new { UserId = userId, ListName = listname }, "GlosserieSSAuth");

                //use listId to get list entries
                var records = _sqlDataAccess.LoadData<EntryModel, dynamic>
                    ("ListeraDB.listeradb.spGetEntriesByList", new { listID = vocabList[0].ListId }, "GlosserieSSAuth");

                return records;

            }
            catch (Exception ex)
            {
                string m = ex.Message;
                string s = ex.StackTrace;
                return new List<EntryModel>();
            }
        }

        //test
        public IEnumerable<VocabListModel> GetVocabListsByUser(int userId)
        {
            try
            {
                var records = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                        ("ListeraDB.listeradb.spGetListByUserID", new { userId = userId }, "GlosserieSSAuth");

                foreach (var vocabList in records)
                {
                    vocabList.ListEntries = _sqlDataAccess.LoadData<EntryModel, dynamic>
                    ("ListeraDB.listeradb.spGetEntriesByList", new { listID = vocabList.ListId }, "GlosserieSSAuth");
                }


                return records;
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                string s = ex.StackTrace;
                return new List<VocabListModel>();
            }
        }

        public UserModel Login(string email, string password)
        {
            return _authenticationService.Login(email, password);
        }

        public bool Register(string email, string password, string confirmpassword)
        {
            return _authenticationService.Register(email, password, confirmpassword);
        }
    }
}

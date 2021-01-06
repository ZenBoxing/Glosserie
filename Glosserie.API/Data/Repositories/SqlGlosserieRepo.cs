using Glosserie.API.Data.DataAccess;
using Glosserie.API.Models;
using Glosserie.API.Utility;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data.Repositories
{
    public class SqlGlosserieRepo //: IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public SqlGlosserieRepo(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }


        public void CreateVocabList(VocabListOptionsModel options)
        {
            //potential options would be number of words and frequency of words
            
            //create VocabListModel
            VocabListModel vocabListModel = new VocabListModel { ListName = options.ListName,
                                                                 UserId = options.UserId};
            //check if listname already exists for this user

            //save VocabListModel to database (look into sql transactions)
            _sqlDataAccess.SaveData<VocabListModel>("spInsertVocabList", vocabListModel, "GlosserieSSAuth");


            PdfLoadedDocument pdf = new PdfLoadedDocument(options.FileContents);
            //change to stringbuilder possibly
            string extractedText = "";

            foreach (PdfPageBase item in pdf.Pages)
            {
                extractedText += item.ExtractText();
            }
            
            //todo: get texthandler through constructor 
            string[] wordArray = TextHandler.GetSeparatedWordArray(extractedText);

            List<EntryModel> entries = new List<EntryModel>();
            
            foreach (var word in wordArray)
            {
                entries.Add(new EntryModel { Word = word});
            }

            //perhaps use table-value parameter
            //foreach (var word in wordArray)
            //{
            //    var record = _sqlDataAccess.LoadData<EntryModel, dynamic>
            //        ("ListeraDB.listeradb.spGetEntryByWord", new { word = word }, "GlosserieSSAuth");
            //}

            //could possibly use sp that takes dif TVP 
            var records = _sqlDataAccess.LoadData<EntryModel, dynamic>
                    ("ListeraDB.listeradb.spGetEntriesByWordList", new { ETT = entries }, "GlosserieSSAuth");

            //get vocablist with ID
            var vocabListWithID = _sqlDataAccess.LoadData<VocabListModel, dynamic>
                ("ListeraDB.listeradb.spGetVocabListByName", new { listname = vocabListModel.ListName }, "GlosserieSSAuth");


            //add dictionary entries to list entries
            List<ListEntryModel> listEntryModels = new List<ListEntryModel>();
            int listID = vocabListWithID.First().ListId;

            foreach (var entry in records)
            {
                listEntryModels.Add(new ListEntryModel { ListID = listID , EntryID = entry.EntryID});
            }
            //insert list entries
            _sqlDataAccess.SaveData<List<ListEntryModel>>("spInsertListEntries", listEntryModels, "GlosserieSSAuth");

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

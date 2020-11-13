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
    public class SqlGlosserieRepo : IGlosserieRepo
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public SqlGlosserieRepo(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }


        public void CreateVocabList(VocabListOptionsModel options)
        {
            PdfLoadedDocument pdf = new PdfLoadedDocument(options.FileContents);
            //change to stringbuilder possibly
            string extractedText = "";

            foreach (PdfPageBase item in pdf.Pages)
            {
                extractedText += item.ExtractText();
            }

            string[] wordArray = TextHandler.GetSeparatedWordArray(extractedText);

            List<EntryModel> entries = new List<EntryModel>();

            //perhaps use table-value parameter
            foreach (var word in wordArray)
            {
                var record = _sqlDataAccess.LoadData<EntryModel, dynamic>
                    ("ListeraDB.listeradb.spGetEntryByWord", new { word = word }, "GlosserieSSAuth");
            }


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

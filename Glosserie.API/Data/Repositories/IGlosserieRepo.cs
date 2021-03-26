using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Data
{
    public interface IGlosserieRepo
    {
        IEnumerable<VocabListModel> GetVocabListsByUser(int userId);
        IEnumerable<EntryModel> GetEntriesByList(int userId, string listname);
        bool CreateVocabList(VocabListOptionsModel options);
        UserModel Login(string email,string password);
        bool Register(string email,string password,string confirmpassword);
        bool DeleteList(int listID);
    }
}

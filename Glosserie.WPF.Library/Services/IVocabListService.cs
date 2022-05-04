using Glosserie.WPF.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public interface IVocabListService
    {
        Task<List<VocabListModel>> GetVocabLists();
        Task<bool> GetCreateVocabList(VocabListOptionsModel options);
        Task<bool> DeleteVocabList(int listID);
    }
}
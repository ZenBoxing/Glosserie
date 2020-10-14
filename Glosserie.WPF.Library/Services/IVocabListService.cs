using Glosserie.WPF.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public interface IVocabListService
    {
        Task<List<VocabListModel>> GetVocabLists();
    }
}
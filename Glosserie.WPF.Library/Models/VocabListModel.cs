using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Library.Models
{
    public class VocabListModel
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }

        public List<EntryModel> VocabList { get; set; }
    }
}

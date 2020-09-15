using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Library.Models
{
    public class EntryModel
    {
        public int EntryID { get; set; }
        public int WordRank { get; set; }
        public string Word { get; set; }
        public string WordType { get; set; }
        public string Definition { get; set; }
    }
}

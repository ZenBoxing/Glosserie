using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Models
{
    public class EntryInsertModel
    {
        public long WordRank { get; set; }
        public string Word { get; set; }
        public string WordType { get; set; }
        public string Definition { get; set; }
    }
}

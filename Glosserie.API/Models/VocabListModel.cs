using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Models
{
    public class VocabListModel
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Models
{
    public class VocabListInsertModel
    {
        public int UserId { get; set; }
        public string ListName { get; set; }
    }
}

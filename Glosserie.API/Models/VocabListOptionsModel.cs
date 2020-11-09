using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Models
{
    public class VocabListOptionsModel
    {
        public byte[] FileContents { get; set; }
        public string Uri { get; set; }
        public int Length { get; set; }
        public string ListName { get; set; }
        public int UserId { get; set; }
    }
}

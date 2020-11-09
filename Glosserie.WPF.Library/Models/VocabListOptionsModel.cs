using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Library.Models
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

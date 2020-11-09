using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Glosserie.API.Utility
{
    public static class TextHandler
    {
        /// <summary>
        ///  Creates a string array of each unique word
        ///  from a text sample. 
        /// </summary>
        /// <param name="sampleText"></param>
        /// <returns>String Array</returns>
        public static string[] GetSeparatedWordArray(string sampleText)
        {
            //matches all non-letter characters
            Regex wordRegex = new Regex("[^a-zA-Z]");

            char[] wordSeparators = { ' ' };

            //Replaces non-letter characters with space
            string lettersOnlyText = wordRegex.Replace(sampleText, " ");
            //Splits sample text into array
            string[] separatedWordArray = lettersOnlyText.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] uniqueWordArray = new HashSet<string>(separatedWordArray).ToArray();
            return uniqueWordArray;
        }
    }
}

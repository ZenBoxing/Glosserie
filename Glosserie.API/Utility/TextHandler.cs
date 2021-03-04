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
            string lettersOnlyText = wordRegex.Replace(sampleText.ToLower(), " ");

            //create list of words 
            List<string> uniqueWordList = new List<string>(lettersOnlyText.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries));
            //sort list
            uniqueWordList.Sort();

            //find duplicate elements and small words in list
            for (int i = 0; i < uniqueWordList.Count; i++)
            {
                if (uniqueWordList[i].Length < 3)
                { 
                    uniqueWordList[i] = " ";
                }

                if (i + 1 < uniqueWordList.Count && uniqueWordList[i] == uniqueWordList[i + 1] )
                {
                    uniqueWordList[i] = " ";
                }
            }
            //remove duplicate elements and small words from list
            uniqueWordList.RemoveAll(x => x == " ");

            return uniqueWordList.ToArray();
        }
    }
}

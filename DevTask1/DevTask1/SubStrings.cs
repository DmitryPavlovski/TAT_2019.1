using System;
using System.Collections.Generic;
using System.Text;

namespace DevTask1
{
    class SubStringsSequence
    {
        StringBuilder Subsequence { get; set; }

        /// <summary>
        /// Constructor forms a string from array of strings and checks on Error
        /// </summary>
        /// <param name="sequence">Array of strings</param>
        public SubStringsSequence(string[] sequence)
        {           
            if (this.ChekForValidity(sequence))
            {
               throw new Exception("String too short!");
            }
            this.Subsequence = new StringBuilder();
            foreach (string word in sequence)
            {
                 this.Subsequence.Append(word).Append(" ");
            }
            this.Subsequence.Remove(this.Subsequence.Length - 1, 1);            
        }

        /// <summary>
        /// Method checks for minimum array length
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private bool ChekForValidity(string[] sequence) => sequence.Length == 0 || sequence[0].Length <= 2;

        /// <summary>
        /// Method search a substring starting with indexFirstElement, but after an element indexPreviousElement 
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="indexFirstElement"></param>
        /// <param name="indexPreviousElement"></param>
        /// <returns></returns>
        public string SearchNextSubstring(string sequence, int indexFirstElement, int indexPreviousElement)
        {
            if (sequence[indexPreviousElement] != sequence[indexPreviousElement + 1])
            {
                return sequence.Substring(indexFirstElement, indexPreviousElement - indexFirstElement + 2);
            }
            else
            {
                return string.Empty;
            }
        }

        ///<summary>
        /// the method search all substrings in string
        /// </summary>
        public List<string> SearchAllSubstrings()
        {
            var listOfSubstring = new List<string>();

            for (int firstElement = 0; firstElement < this.Subsequence.Length; firstElement++)
            {
                for (int lastElement = firstElement; lastElement < this.Subsequence.Length - 1; lastElement++)
                {
                    var substring = this.SearchNextSubstring(this.Subsequence.ToString(), firstElement, lastElement);

                    if (substring.Length>1)
                    {
                        listOfSubstring.Add(substring);
                    }

                    if (this.Subsequence.Length - lastElement > 1 && this.Subsequence[lastElement] == this.Subsequence[lastElement + 1])
                    {
                        break;
                    }
                }
            }

            return listOfSubstring;
        }

        /// <summary>
        /// method display all substring
        /// </summary>
        /// <param name="list"></param>
        public void DisplayAllSubstring(List<string> list)
        {
            foreach(var substring in list)
            {
                Console.WriteLine(substring);
            }
        }
     }
}
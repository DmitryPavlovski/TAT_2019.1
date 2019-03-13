using System;
using System.Text;

namespace DevTask1
{
    class SubStringsSequence
    {
        private StringBuilder subsequence;
        /// <summary>
        /// Constructor forms a string from array of strings and checks on Error
        /// </summary>
        /// <param name="sequence">Array of strings</param>
        public SubStringsSequence(string[] sequence)
        {           
                if (ChekForEmptiness(sequence))
                {
                    throw new Exception("String too short!");
                }
                subsequence = new StringBuilder();
                foreach (string word in sequence)
                {
                    subsequence.Append(word).Append(" ");
                }
                subsequence.Remove(subsequence.Length - 1, 1);            
        }
        /// <summary>
        /// Method checks for minimum array length
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ChekForEmptiness(string[] str)
        {
            return str.Length == 0 || str[0].Length <= 2;
        }
        /// <summary>
        /// Method search a substring starting with indexFirstElement, but after an element indexPreviousElement 
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="indexFirstElement"></param>
        /// <param name="indexPreviousElement"></param>
        /// <returns></returns>
        public string SearchNextSubstring(string sequence, int indexFirstElement, int indexPreviousElement)
        {
            if (sequence[indexPreviousElement] == sequence[indexPreviousElement + 1])
            {
                return "0";
            }
            return sequence.Substring(indexFirstElement, indexPreviousElement - indexFirstElement + 2);           
        }
        ///<summary>
        /// the method takes a string and displays all the substrings.
        /// </summary>
        public void DisplayAndSearchAllSubstrings()
        {
            for (int firstElement = 0; firstElement < subsequence.Length; firstElement++)
            {
                for (int lastElevent = firstElement; lastElevent < subsequence.Length - 1; lastElevent++)
                {
                    if(SearchNextSubstring(subsequence.ToString(), firstElement, lastElevent).Length>1)
                    {
                        Console.WriteLine(SearchNextSubstring(subsequence.ToString(),firstElement, lastElevent));
                    }
                    if (subsequence.Length - lastElevent > 1 && subsequence[lastElevent] == subsequence[lastElevent + 1])
                    {
                        break;
                    }
                }
            }
        }
     }
}
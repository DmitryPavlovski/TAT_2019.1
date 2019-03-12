using System;
using System.Text;

namespace DevTask1
{
    class SubStrings
    {
        private StringBuilder str;
        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="str">Array of strings</param>
        public SubStrings(string[] str)
        {           
                if (ChekForEmptiness(str))
                {
                    throw new Exception("String too short!");
                }
                this.str = new StringBuilder();
                foreach (string word in str)
                {
                    this.str.Append(word).Append(" ");
                }
                this.str.Remove(this.str.Length - 1, 1);            
        }
        private bool ChekForEmptiness(string[] str)
        {
            return str.Length == 0 || str[0].Length <= 2;
        }
        public string SearchNextSubstring(string str, int indexFirstElement, int indexPreviousElement)
        {
            if (str[indexPreviousElement] == str[indexPreviousElement + 1])
            {
                return "0";
            }
            return str.Substring(indexFirstElement, indexPreviousElement - indexFirstElement + 2);           
        }
        ///<summary>
        /// the method takes a string and displays all the substrings.
        /// </summary>
        public void DisplayAndSearchAllSubstrings()
        {
            for (int firstElement = 0; firstElement < str.Length; firstElement++)
            {
                for (int lastElevent = firstElement; lastElevent < str.Length - 1; lastElevent++)
                {
                    if(SearchNextSubstring( this.str.ToString(), firstElement, lastElevent).Length>1)
                    {
                        Console.WriteLine(SearchNextSubstring(this.str.ToString(),firstElement, lastElevent));
                    }
                    if (str.Length - lastElevent > 1 && str[lastElevent] == str[lastElevent + 1])
                    {
                        break;
                    }
                }
            }
        }
       
    }
}

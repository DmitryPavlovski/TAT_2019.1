using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTask1
{
    class SubStrings
    {
        StringBuilder str;
        /// <summary>
        /// Constructor forms a string from array of strings
        /// </summary>
        /// <param name="str">Array of strings</param>
        public SubStrings(string[] str)
        {
            this.str = new StringBuilder();
            foreach (string word in str)
            {
                this.str.Append(word).Append(" ");
            }
            this.str.Remove(this.str.Length - 1, 1);

        }
        ///<summary>
        /// the method takes a string and displays all the substrings.
        /// </summary>
        public void SearchSubstrings()
        {
            String str = String.Join("", this.str);
            for (int firstElement = 0; firstElement < str.Length; firstElement++)
            {
                for (int lastElevent = firstElement; lastElevent <= str.Length - 1; lastElevent++)
                {
                    if (lastElevent - firstElement > 0)
                        Console.WriteLine(str.Substring(firstElement, lastElevent - firstElement + 1));
                    if (str.Length - lastElevent > 1
                        && str[lastElevent] == str[lastElevent + 1]) break;
                }
            }
        }
    }
}

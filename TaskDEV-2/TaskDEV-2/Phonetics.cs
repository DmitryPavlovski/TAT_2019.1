using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDEV_2
{
    class Phonetics
    {
        private StringBuilder word;

        public Phonetics(string str)
        {
            word = new StringBuilder();
            word.Append(str);
        }
        string ParseOnSounds()
        {
            StringBuilder phoneticsWord;
            for(int i=0; i<word.Length;i++)
            {
                // if (word[i]==) TODO: word reading method
            }
            return string.Empty;//phoneticsWord.ToString();
        }
    }
}

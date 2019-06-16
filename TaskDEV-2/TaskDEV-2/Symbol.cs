using System.Linq;

namespace TaskDEV_2
{
    /// <summary>
    /// Сlass for letters
    /// </summary>
    public class Symbol
    {        
        public char Letter { get; set; }
        public string Sound { get; set; } = "other";
        public bool IsStress { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public Symbol(char symbol)
        {
            this.Letter = symbol;
            if (Phonetics.vowels.Contains(symbol))
            {
                this.Sound = "vowel";
            }
            if (Phonetics.Consonants.Contains(symbol))
            {
                this.Sound = "consonant";
            }
        }
    }
}

using System.Linq;

namespace TaskDEV_2
{
    /// <summary>
    /// Сlass for letters
    /// </summary>
    class Symbol
    {
        internal char symbol;
        internal string sound = "other";
        internal bool isStress = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public Symbol(char symbol)
        {
            this.symbol = symbol;
            if (Phonetics.vowels.Contains(symbol))
            {
                this.sound = "vowel";
            }
            if (Phonetics.Consonants.Contains(symbol))
            {
                this.sound = "consonant";
            }
        }
    }
}

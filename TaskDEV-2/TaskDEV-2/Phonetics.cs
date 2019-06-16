using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskDEV_2
{
    /// <summary>
    /// class for convert word in phonetics appearance
    /// </summary>
    public class Phonetics
    {
        public string Word { get; set; } = string.Empty;
        public StringBuilder Phonemes { get; set; } = new StringBuilder();
        internal static readonly string vowels = "аоиеёэыуюя";
        internal static readonly string Consonants = "бвгджзйлмнрпфктшсхцчщ";
        private static readonly Dictionary<char, char> vowelAfterConsonant = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };
        private static readonly Dictionary<char, string> vowelAfterVowel = new Dictionary<char, string>
        {
            ['ю'] = "й'у",
            ['я'] = "й'а",
            ['ё'] = "й'о",
            ['е'] = "й'э"
        };
        private static readonly Dictionary<char, char> voicingConsonant = new Dictionary<char, char>
        {
            ['б'] = 'п', 
            ['в'] = 'ф', 
            ['г'] = 'к', 
            ['д'] = 'т', 
            ['ж'] = 'ш', 
            ['з'] = 'с'
        };
        private static readonly Dictionary<char, char> deafConsonant = new Dictionary<char, char>
        {
            ['п'] = 'б', 
            ['ф'] = 'в', 
            ['к'] = 'г', 
            ['т'] = 'д',
            ['ш'] = 'ж',
            ['с'] = 'з'
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="word"></param>
        public Phonetics(string word)
        { 
            this.Word = word.ToLower();
            this.CheckOnPlusInStartWord();
            this.CheckOnValidPlus();
            this.CheckOnTwoPlus();
            this.CheckOnPlusAfterConsonant();
            this.CheckOnNoPlus();
            this.CheckOnLengthWord();
        }

        /// <summary>
        /// method for check on plus in start word
        /// </summary>
        /// <returns></returns>
        public bool CheckOnPlusInStartWord()
        {
            if(this.Word.Contains('+') && this.Word.IndexOf('+') == 0)
            {
                throw new FormatException("Plus first symbol!!!");
            }

            return true;
        }

        /// <summary>
        /// method for check on valid plus
        /// </summary>
        /// <returns></returns>
        public bool CheckOnValidPlus()
        {
            if (this.Word.Contains('ё'))
            {
                if (this.Word.Contains('+') && this.Word[this.Word.IndexOf('+') - 1] != 'ё')
                {
                    throw new FormatException("Not valid stress!!!");
                }
            }

            return true;
        }

        /// <summary>
        /// method for check on plus after consonant
        /// </summary>
        /// <returns></returns>
        public bool CheckOnPlusAfterConsonant()
        {
            if(this.Word.Contains('+') && Consonants.Any(x => x == this.Word[this.Word.IndexOf('+')-1]))
            {
                throw new FormatException("Stress after consonant!!!");
            }

            return true;
        }

        /// <summary>
        /// Method for check on no plus,
        /// if no plus and only one vowel or have ё add plus
        /// </summary>
        /// <param name="word"></param>
        public bool CheckOnNoPlus()
        {
            if (!this.Word.Contains('+'))
            {                
                if (this.Word.Count(x => vowels.Contains(x))==1)
                {
                    this.Word = this.Word.Insert(this.Word.IndexOf(this.Word.First(x => vowels.Contains(x)))+1, "+");
                }
                else if (this.Word.Contains('ё'))
                {
                    this.Word = this.Word.Insert(this.Word.IndexOf('ё') + 1, "+");
                }
                else throw new FormatException("Need right show stress!!!");
            }

            return true;
        }

        /// <summary>
        /// Method for check on two plus in word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool CheckOnTwoPlus()
        {
            if (this.Word.Count(x => x == '+')>1)
            {
                throw new FormatException("Wrote more then one stress!!!");
            }

            return true;
        }

        /// <summary>
        /// method for check on empty word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool CheckOnLengthWord()
        {
            if (this.Word.Length == 0)
            {
                throw new FormatException("Need write word!!!");
            }

            return true;
        }

        /// <summary>
        /// Method parses the word into letters
        /// </summary>
        /// <returns> symbols = word parses into letters </returns>
        public Symbol[] ParsingWord()
        {
            var symbols = new Symbol[this.Word.Length-1];
            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = new Symbol(this.Word[i]);
                if (i!= this.Word.Length-1 && this.Word[i + 1] == '+')
                {
                    symbols[i].IsStress = true;
                    this.Word = this.Word.Remove(i + 1, 1);
                }
            }

            return symbols;
        }

        /// <summary>
        /// Method convert word in phonetics form
        /// </summary>
        /// <param name="symbols" >array symbols class Symbol</param>
        /// <returns>phonemes</returns>
        public StringBuilder ConvertWordToPhonetics(Symbol[] symbols)
        {
            for (int i = 0 ; i < this.Word.Length; i++)
            {
                switch(symbols[i].Sound)
                {
                    case "vowel":
                        this.Phonemes.Append(this.AddVowel(i, symbols));
                        continue;
                    case "consonant":
                        this.Phonemes.Append(this.AddConsonant(i, symbols));
                        continue;
                    case "other":
                        if (symbols[i].Letter == 'ь')
                        {
                            this.Phonemes.Append("'");
                        }
                        continue;
                }
            }

            return this.Phonemes;
        }

        /// <summary>
        /// Method convert vowel letters into sounds
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbols"></param>
        public string AddVowel (int index, Symbol[] symbols)
        {
            if (index != 0 && symbols[index - 1].Sound == "consonant" && vowelAfterConsonant.ContainsKey(symbols[index].Letter))
            {
                return "'" + vowelAfterConsonant[symbols[index].Letter];
            }
            if ((symbols[index].IsStress || index == 0 || symbols[index-1].Sound == "vowel" || symbols[index - 1].Sound == "other")
                && vowelAfterVowel.ContainsKey(symbols[index].Letter))
            {
                return vowelAfterVowel[symbols[index].Letter];
            }
            if (symbols[index].Letter == 'о' && !symbols[index].IsStress)
            {
                return "а";
            }

            return symbols[index].Letter.ToString();
        }

        /// <summary>
        /// Method convert consonant letters into sounds
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbols"></param>
        public string AddConsonant(int index, Symbol[] symbols)
        {
            if(index == this.Word.Length - 1 && voicingConsonant.ContainsKey(symbols[index].Letter))
            {
                return voicingConsonant[symbols[index].Letter].ToString();
            }
            else if(index == this.Word.Length - 1)
            {
                return symbols[index].Letter.ToString();
            }
            if (symbols[index + 1].Sound == "consonant")
            {
                if (deafConsonant.ContainsKey(symbols[index+1].Letter) && voicingConsonant.ContainsKey(symbols[index].Letter))
                {
                    return voicingConsonant[symbols[index].Letter].ToString();
                }
                if (deafConsonant.ContainsKey(symbols[index].Letter) && voicingConsonant.ContainsKey(symbols[index + 1].Letter))
                {
                    return deafConsonant[symbols[index].Letter].ToString();
                }
            }

            return symbols[index].Letter.ToString();
        }

        /// <summary>
        /// Method display phonetics form word
        /// </summary>
        /// <param name="phonemes"></param>
        public void DisplayPhonemes(StringBuilder phonemes) => Console.WriteLine(this.Word + " -> " + phonemes);
    }
}
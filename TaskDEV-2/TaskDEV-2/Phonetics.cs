using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskDEV_2
{
    /// <summary>
    /// class for convert word in phonetics appearance
    /// </summary>
    class Phonetics
    {
        private string word = string.Empty;
        private StringBuilder phonemes = new StringBuilder();
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
            this.word = word.ToLower();
            this.CheckOnException(this.word);
        }

        /// <summary>
        /// Method for check on all Exection
        /// </summary>
        /// <param name="word"></param>
        private void CheckOnException(string word)
        {
            if (word.Length == 0)
            {
                throw new FormatException("Need write word!!!");
            }
            if (word.IndexOf('+') != word.LastIndexOf('+'))
            {
                throw new FormatException("Wrote two stress!!!");
            }
            int indexFirstVowel = word.Length - 1, indexLastVowel = 0;
            if (!word.Contains('+'))
            {
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (word.IndexOf(vowels[i]) >= 0 && indexFirstVowel > word.IndexOf(vowels[i]))
                    {
                        indexFirstVowel = word.IndexOf(vowels[i]);
                    }
                    if (word.LastIndexOf(vowels[i]) > 0 && indexLastVowel < word.LastIndexOf(vowels[i]))
                    {
                        indexLastVowel = word.LastIndexOf(vowels[i]);
                    }
                }
                if (indexFirstVowel == indexLastVowel)
                {
                    this.word = word.Insert(indexFirstVowel + 1, "+");
                }
                else if (word.Contains('ё'))
                {
                    this.word = word.Insert(word.IndexOf('ё') + 1, "+");
                }
                else throw new FormatException("Need right show stress!!!");
            }
        }

        /// <summary>
        /// Method parses the word into letters
        /// </summary>
        /// <returns> symbols = word parses into letters </returns>
        public Symbol[] ParsingWord()
        {
            var symbols = new Symbol[this.word.Length-1];
            for (int i = 0; i < symbols.Length; i++)
            {                
                symbols[i] = new Symbol(this.word[i]);
                if (i!= this.word.Length-1 && this.word[i + 1] == '+')
                {
                    symbols[i].isStress = true;
                    this.word = this.word.Remove(i + 1, 1);
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
            for (int i = 0 ; i < this.word.Length; i++)
            {
                switch(symbols[i].sound)
                {
                    case "vowel":
                        this.AddVowel(i, symbols);
                        continue;
                    case "consonant":
                        this.AddConsonant(i, symbols);
                        continue;
                    case "other":
                        if (symbols[i].symbol == 'ь')
                        {
                            this.phonemes.Append("'");
                        }
                        continue;
                }
            }

            return this.phonemes;
        }

        /// <summary>
        /// Method convert vowel letters into sounds
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbols"></param>
        void AddVowel (int index, Symbol[] symbols)
        {
            if (index != 0 && symbols[index - 1].sound == "consonant" && vowelAfterConsonant.ContainsKey(symbols[index].symbol))
            {
                this.phonemes.Append("'" + vowelAfterConsonant[symbols[index].symbol]);
                return ;
            }
            if ((symbols[index].isStress || index == 0 || symbols[index-1].sound == "vowel" || symbols[index - 1].sound == "other")
                && vowelAfterVowel.ContainsKey(symbols[index].symbol))
            {
                this.phonemes.Append(vowelAfterVowel[symbols[index].symbol]);

                return ;
            }
            if (symbols[index].symbol == 'о' && !symbols[index].isStress)
            {
                this.phonemes.Append("а");

                return;
            }
            this.phonemes.Append(symbols[index].symbol);
        }

        /// <summary>
        /// Method convert consonant letters into sounds
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbols"></param>
        void AddConsonant(int index, Symbol[] symbols)
        {
            if(index == this.word.Length - 1 && voicingConsonant.ContainsKey(symbols[index].symbol))
            {
                this.phonemes.Append(voicingConsonant[symbols[index].symbol]);

                return;
            }
            else if(index == this.word.Length - 1)
            {
                this.phonemes.Append(symbols[index].symbol);

                return;
            }
            if (symbols[index + 1].sound == "consonant")
            {
                if (deafConsonant.ContainsKey(symbols[index+1].symbol) && voicingConsonant.ContainsKey(symbols[index].symbol))
                {
                    this.phonemes.Append(voicingConsonant[symbols[index].symbol]);

                    return;
                }
                if (deafConsonant.ContainsKey(symbols[index].symbol) && voicingConsonant.ContainsKey(symbols[index + 1].symbol))
                {
                    this.phonemes.Append(deafConsonant[symbols[index].symbol]);

                    return;
                }
            }
            this.phonemes.Append(symbols[index].symbol);
        }

        /// <summary>
        /// Method display phonetics form word
        /// </summary>
        /// <param name="phonemes"></param>
        public void DisplayPhonemes(StringBuilder phonemes) => Console.WriteLine(this.word + " -> " + phonemes);
    }
}
﻿using System;
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
        internal readonly string vowels = "аоиеёэыуюя";
        internal readonly string deafConsonants = "пфктшсхцчщ";
        internal readonly string voicConsonants = "бвгджзйлмнр";
        private readonly Dictionary<char, char> vowelAfterConsonant = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };
        private readonly Dictionary<char, string> vowelAfterVowel = new Dictionary<char, string>
        {
            ['ю'] = "й'у",
            ['я'] = "й'а",
            ['ё'] = "й'о",
            ['е'] = "й'э"
        };
        private readonly Dictionary<char, char> voicingConsonant = new Dictionary<char, char>
        {
            ['б'] = 'п', ['й']='й',
            ['в'] = 'ф', ['л']='л',
            ['г'] = 'к', ['м']='м',
            ['д'] = 'т', ['н']='н',
            ['ж'] = 'ш', ['р']='р',
            ['з'] = 'с'
        };
        private readonly Dictionary<char, char> deafConsonant = new Dictionary<char, char>
        {
            ['п'] = 'б', ['х']='х',
            ['ф'] = 'в', ['ц']='ц',
            ['к'] = 'г', ['щ']='щ',
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
            if(word.Length==0)
            {
                throw new FormatException("Need write word!!!");
            }
            this.word = word.ToLower();
            if (word.IndexOf('+') != word.LastIndexOf('+'))
            {
                throw new FormatException("Wrote two stress!!!");
            }
            int indexFirstVowel = word.Length-1;
            int indexLastVowel = 0;
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

        public Phonetics()
        {
        }
        /// <summary>
        /// Method parses the word into letters
        /// </summary>
        /// <returns> symbols = word parses into letters </returns>
        public Symbol[] ParsingWord()
        {
            Symbol[] symbols = new Symbol[word.Length-1];
            for (int i = 0; i < symbols.Length; i++)
            {                
                symbols[i] = new Symbol(word[i]);
                if (i!=word.Length-1 && word[i + 1] == '+')
                {
                    symbols[i].stress = true;
                    word = word.Remove(i + 1, 1);
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
            for (int i = 0 ; i < word.Length; i++)
            {
                switch(symbols[i].sound)
                {
                    case "vowel":
                        AddVowel(i, symbols);
                        continue;
                    case "consonant":
                        AddConsonant(i, symbols);
                        continue;
                    case "other":
                        if (symbols[i].symbol == 'ь')
                        {
                            phonemes.Append("'");
                        }
                        continue;
                }
            }
            return phonemes;
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
                phonemes.Append("'" + vowelAfterConsonant[symbols[index].symbol]);
                return ;
            }
            if ((symbols[index].stress || index == 0 || symbols[index-1].sound == "vowel" || symbols[index - 1].sound == "other")
                && vowelAfterVowel.ContainsKey(symbols[index].symbol))
            {
                phonemes.Append(vowelAfterVowel[symbols[index].symbol]);
                return ;
            }
            if (symbols[index].symbol == 'о' && !symbols[index].stress)
            {
                phonemes.Append("а");
                return;
            }
            phonemes.Append(symbols[index].symbol);
        }
        /// <summary>
        /// Method convert consonant letters into sounds
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbols"></param>
        void AddConsonant(int index, Symbol[] symbols)
        {
            if(index == word.Length - 1 && symbols[index].deafness == 2)
            {
                phonemes.Append(voicingConsonant[symbols[index].symbol]);
                return;
            }
            else if(index == word.Length - 1)
            {
                phonemes.Append(symbols[index].symbol);
                return;
            }
            if (symbols[index + 1].sound == "consonant")
            {
                if (symbols[index+1].deafness == 1 && symbols[index].deafness == 2)
                {
                    phonemes.Append(voicingConsonant[symbols[index].symbol]);
                    return;
                }
                if (symbols[index + 1].deafness == 2 && symbols[index].deafness == 1)
                {
                    phonemes.Append(deafConsonant[symbols[index].symbol]);
                    return;
                }
            }
            phonemes.Append(symbols[index].symbol);
        }
        /// <summary>
        /// Method display phonetics form word
        /// </summary>
        /// <param name="phonemes"></param>
        public void DisplayPhonemes(StringBuilder phonemes)
        {
            Console.WriteLine(word + " -> " + phonemes);
        }
    }
    class Symbol
    {
        /// <summary>
        /// Сlass for letters
        /// </summary>
        internal char symbol;
        internal string sound = "other";
        internal bool stress = false;
        internal int deafness = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public Symbol(char symbol)
        {
            var buf = new Phonetics();
            this.symbol = symbol;
            if (buf.vowels.Contains(symbol))
            {
                sound = "vowel";
            }
            if(buf.deafConsonants.Contains(symbol) || buf.voicConsonants.Contains(symbol))
            {
                sound = "consonant";
                if (buf.deafConsonants.Contains(symbol))
                {
                    deafness = 1;
                }
                else deafness = 2;
            }
        }
    }
}
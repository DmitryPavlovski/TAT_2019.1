using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestClass]
    public class PhoneticsTest
    {
        [TestMethod]
        public void ConvertWordToPhonetics_Word_PhoneticsFormReturned()
        {
            string words = "бе+лка";
            var expected = "б'элка";

            var phonetics = new Phonetics(words);
            var phoneticsForm = phonetics.ConvertWordToPhonetics(phonetics.ParsingWord()).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }

        [TestMethod]
        public void AddConsonant_Consonant_PhoneticsFormReturned()
        {
            var letter = 'з';
            var expected = "с";
            var letters = new Symbol[1];
            letters[0] = new Symbol(letter);

            var phonetics = new Phonetics(letter.ToString());
            var phoneticsForm = phonetics.AddConsonant(0, letters).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }

        [TestMethod]
        public void AddVowel_Vowel_PhoneticsFormReturned()
        {
            var letter = 'о';
            var expected = "а";
            var letters = new Symbol[1];
            letters[0] = new Symbol(letter);

            var phonetics = new Phonetics(letter.ToString());
            var phoneticsForm = phonetics.AddVowel(0, letters).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }
    }
}

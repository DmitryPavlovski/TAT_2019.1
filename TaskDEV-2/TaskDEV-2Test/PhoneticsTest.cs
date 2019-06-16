using NUnit.Framework;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestFixture]
    public class PhoneticsTest
    {
        [TestCase("обороноспосо+бность", "абаранаспасобнаст'")]
        public void ConvertWordToPhonetics_Word_PhoneticsFormReturned(string inputWord, string expected)
        {
            var phonetics = new Phonetics(inputWord);
            var phoneticsForm = phonetics.ConvertWordToPhonetics(phonetics.ParsingWord()).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }

        [TestCase("по+езд", "п")]
        public void AddConsonant_Consonant_PhoneticsFormReturned(string inputWord, string expected)
        {
            var phonetics = new Phonetics(inputWord);
            var letters = phonetics.ParsingWord();

            var phoneticsForm = phonetics.AddConsonant(0, letters).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }

        [TestCase("о+блако", "а")]
        public void AddVowel_Vowel_PhoneticsFormReturned(string inputWord, string expected)
        {
            var phonetics = new Phonetics(inputWord);
            var letters = phonetics.ParsingWord();

            var phoneticsForm = phonetics.AddVowel(5, letters).ToString();

            Assert.AreEqual(expected, phoneticsForm);
        }
    }
}

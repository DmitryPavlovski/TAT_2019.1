using NUnit.Framework;
using System;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestFixture]
    public class ValidInputDataTest
    {
        [TestCase("ёлка", "ё+лка")]
        public void PhoneticsConstructor_WordWithoutPlus_WordWithPlusReturned(string inputWord, string expected)
        {
            var phonetics = new Phonetics(inputWord);

            Assert.AreEqual(expected, phonetics.Word);
        }

        [TestCase("боры")]
        [TestCase("ё+лка+")]
        [TestCase("ёлка+")]
        [TestCase("бор+")]
        [TestCase("")]
        [TestCase("+ёлка")]
        public void PhoneticsConstructor_NoValidInpput_ExeptionReturned(string inputWord) => Assert.Throws<FormatException>(() => new Phonetics(inputWord));

        [TestCase("бор", "бо+р")]
        public void CheckOnNoPlus_WordWithOneVowel_WordWithPlusReturned(string inputWord, string expected)
        {
            var phonetics = new Phonetics(inputWord);
            phonetics.CheckOnNoPlus();

            Assert.AreEqual(expected, phonetics.Word);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestClass]
    public class ValidInputDataTest
    {
        [TestMethod]
        public void CheckOnNoPlus_WordWithoutPlus_WordWithPlusReturned()
        {
            string word = "ёлка";
            string expected = "ё+лка";

            var phonetics = new Phonetics(word);
            phonetics.CheckOnNoPlus();

            Assert.AreEqual(expected, phonetics.Word);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Need right show stress!!!")]
        public void CheckOnNoPlus_WordWithoutPlus_ExceptionPlusReturned()
        {
            string[] words = { "боры+", "ёлка+", "бор", "ёлка", "ё+лка+", "боры" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnTwoPlus();
                count++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),"Wrote more then one stress!!!")]
        public void CheckOnTwoPlus_WordWithTwoPlusInDefferentPosition_ExceptionReturned()
        {
            string[] words = { "боры+", "ёлка+", "бор", "ёлка", "ё+лка+" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnTwoPlus();
                count++;
            }
        }

        [TestMethod]
        public void CheckOnNoPlus_WordWithOneVowel_WordWithPlusReturned()
        {
            string word = "бор";
            string expected = "бо+р";

            var phonetics = new Phonetics(word);
            phonetics.CheckOnNoPlus();

            Assert.AreEqual(expected, phonetics.Word);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Not valid stress!!!")]
        public void CheckOnValidPlus_WordWithPlusInDifferentPisition_ExceptionReturned()
        {
            string[] words = { "боры+", "ёлка+", "бор", "ёлка" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnValidPlus();
                count++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Stress after consonant!!!")]
        public void CheckOnPlusAfterConsonant_WordWithPlusAfterConsonant_ExceptionReturned()
        {
            string[] words = { "боры+", "ёлка+", "бор+", "ёлка" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnPlusAfterConsonant();
                count++;
            }
        }

        [TestMethod]
        public void CheckOnPlusAfterConsonant_WordWithPlusInDefferentPosition_TrueReturned()
        {
            string[] words = { "боры+", "ёлка+", "бор", "ёлка" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnPlusAfterConsonant();
                count++;
            }

            Assert.IsTrue(isFlag);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Need write word!!!")]
        public void CheckOnLengthWord_WordWithDefferentLength_ExceptionReturned()
        {
            string[] words = { "б", "ёлка+", "бор+", "ёлка", "" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnLengthWord();
                count++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Plus first symbol!!!")]
        public void CheckOnPlusInStartWord_WordWithDefferentPosition_ExceptionReturned()
        {
            string[] words = { "б", "ёлка+", "бор+", "+ёлка", "" };
            int count = 0;

            bool isFlag = false;
            var phonetics = new Phonetics[words.Length];
            foreach (var word in words)
            {
                phonetics[count] = new Phonetics(word);
                isFlag = phonetics[count].CheckOnPlusInStartWord();
                count++;
            }
        }
    }
}

using NUnit.Framework;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestFixture]
    public class SymbolTest
    {
        [TestCase('а', "vowel")]
        [TestCase('б', "consonant")]
        [TestCase('ь', "other")]
        public void Symbol_Vowel_VowelReturned(char inputLetter, string expected)
        {
            var symbol = new Symbol(inputLetter);

            Assert.AreEqual(expected, symbol.Sound);
        }
    }
}

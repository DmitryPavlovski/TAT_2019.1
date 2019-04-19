using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDEV_2;

namespace TaskDEV_2Test
{
    [TestClass]
    public class SymbolTest
    {
        [TestMethod]
        public void Symbol_Vowel_VowelReturned()
        {
            char letter = 'а';
            string expected = "vowel";

            var symbol = new Symbol(letter);

            Assert.AreEqual(expected, symbol.Sound);
        }

        [TestMethod]
        public void Symbol_Consonant_ConsonantReturned()
        {
            char letter = 'б';
            string expected = "consonant";

            var symbol = new Symbol(letter);

            Assert.AreEqual(expected, symbol.Sound);
        }

        [TestMethod]
        public void Symbol_Other_OtherReturned()
        {
            char letter = 'ь';
            string expected = "other";

            var symbol = new Symbol(letter);

            Assert.AreEqual(expected, symbol.Sound);
        }
    }
}

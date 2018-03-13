using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordsUnscrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void ScrambledWordsMatchesInList()
        {
            string[] words = {"cat", "string", "world", "�������"};
            string[] scrambledWords = {"tca", "tsring", "�������", "lowrd"};
            var matchedWords = _wordMatcher.Match(scrambledWords, words);
            Assert.IsTrue(matchedWords.Count.Equals(4));
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("tca"));
            Assert.IsTrue(matchedWords[0].Word.Equals("cat"));
        }
    }
}

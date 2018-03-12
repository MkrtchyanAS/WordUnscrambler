using System;
using System.Collections.Generic;
using System.Text;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach(var scrambledWord in scrambledWords)
            {
                string scrambledWordLower = scrambledWord.ToLower();
                foreach (var word in wordList)
                {
                    if(scrambledWord.Equals(word, StringComparison.CurrentCultureIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWordLower, word));
                    }
                    else
                    {
                        var scrambledWordsArray = scrambledWordLower.ToCharArray();
                        var wordsArray = word.ToCharArray();

                        Array.Sort(scrambledWordsArray);
                        Array.Sort(wordsArray);

                        var sortedScrambledWord = new string(scrambledWordsArray);
                        var sortedWord = new string(wordsArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.CurrentCultureIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWordLower, word));
                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;

        }
    }
}

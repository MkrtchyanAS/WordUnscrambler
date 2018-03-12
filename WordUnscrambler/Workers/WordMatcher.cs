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
                    if(scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        Console.WriteLine("For debug only ***scrambledWord.Equals***: {0}, {1}", word, scrambledWord);
                    }
                    else
                    {
                        var scrambledWordsArray = scrambledWord.ToCharArray();
                        var wordsArray = word.ToCharArray();

                        Array.Sort(scrambledWordsArray);
                        Array.Sort(wordsArray);

                        var sortedScrambledWord = new string(scrambledWordsArray);
                        var sortedWord = new string(wordsArray);
                        Console.WriteLine("For debug only ***sortedWords***: {0}, {1}", sortedWord, sortedScrambledWord);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                    Console.WriteLine("For debug only ***scrambledWords***: {0}", scrambledWord);
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
            Console.WriteLine("For debug only ***BuildMatchedWord***: {0}, {1}", word, scrambledWord);
            return matchedWord;

        }
    }
}

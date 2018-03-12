using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private const string wordListFileName = "WordList.txt";
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            bool continueUnscrambling = true;

            do
            {
                Console.WriteLine("Please, enter an option: F for file; M for manual: ");
                var option = Console.ReadLine() ?? string.Empty;

                switch(option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Please, input a file path: ");
                        ExecuteScramblingInFile();
                        break;
                    case "M":
                        Console.WriteLine("Please input a words: ");
                        ExecuteScramblingManually();
                        break;
                    default:
                        Console.WriteLine("Option was not recognized.");
                        break;
                }

                var continueDecision = string.Empty;
                
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = Console.ReadLine() ?? string.Empty;

                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                            !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));
                continueUnscrambling = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueUnscrambling);
        }

        private static void ExecuteScramblingManually()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambldWords(scrambledWords);
        }


        private static void ExecuteScramblingInFile()
        {
            var filePath = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filePath);
            DisplayMatchedUnscrambldWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambldWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine("Matches found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches found!");
            }
        }

    }
}

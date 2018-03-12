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
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            try
            {
                bool continueUnscrambling = true;

                do
                {
                    Console.WriteLine(Constants.HowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine(Constants.EnterViaFile);
                            ExecuteScramblingInFile();
                            break;
                        case Constants.Manually:
                            Console.WriteLine(Constants.EnterManually);
                            ExecuteScramblingManually();
                            break;
                        default:
                            Console.WriteLine(Constants.OptionNotRecognized);
                            break;
                    }

                    var continueDecision = string.Empty;

                    do
                    {
                        Console.WriteLine(Constants.ContinueOptions);
                        continueDecision = Console.ReadLine() ?? string.Empty;

                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                                !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));
                    continueUnscrambling = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueUnscrambling);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramTerminated + ex.Message);
            }
            
        }

        private static void ExecuteScramblingManually()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            manualInput = manualInput.Replace(" ", string.Empty);
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambldWords(scrambledWords);
        }


        private static void ExecuteScramblingInFile()
        {
            try
            {
                var filePath = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filePath);
                DisplayMatchedUnscrambldWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded, ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambldWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }

    }
}

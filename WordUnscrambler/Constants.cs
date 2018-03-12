using System;
using System.Collections.Generic;
using System.Text;

namespace WordUnscrambler
{
    class Constants
    {
        public const string HowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: F - file / M - manually: ";
        public const string ContinueOptions = "Would you like to continue? Y/N: ";

        public const string EnterViaFile = "Enter full path including the file name: ";
        public const string EnterManually = "Enter word(s) manually separated by commas if multiple: ";
        public const string OptionNotRecognized = "The option was not recognized.";

        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because of error: {0}";
        public const string ErrorProgramTerminated = "The program will be terminated.";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches have been found.";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manually = "M";

        public const string wordListFileName = "WordList.txt";
    }
}

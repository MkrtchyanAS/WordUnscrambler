using System;
using System.Collections.Generic;
using System.Text;

namespace WordUnscrambler.Data
{
    public struct MatchedWord
    {
        public string ScrambledWord { get; set; }
        public string Word { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public static class GameConstants
    {
        private const int k_SequenceLength = 4;
        private const int k_MinGuesses = 4;
        private const int k_MaxGuesses = 10;

        public static int SequenceLength
        {
            get { return k_SequenceLength; }
        }

        public static int MinGuesses
        {
            get { return k_MinGuesses; }
        }

        public static int MaxGuesses
        {
            get { return k_MaxGuesses; }
        }
    }
}

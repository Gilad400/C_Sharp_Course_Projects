using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_Logic
{
    public class Guess
    {
        private readonly eGamePins[] r_GuessSequence;
        private int m_ExactMatches;
        private int m_PartialMatches;

        public Guess(eGamePins[] i_UserGuess, eGamePins[] i_SecretSequence)
        {
            r_GuessSequence = new eGamePins[i_UserGuess.Length];
            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                r_GuessSequence[i] = i_UserGuess[i];
            }

            m_ExactMatches = calculateExactMatches(i_UserGuess, i_SecretSequence);
            m_PartialMatches = calculatePartialMatches(i_UserGuess, i_SecretSequence);
        }

        public eGamePins[] GuessSequence
        {
            get { return r_GuessSequence; }
        }

        public int ExactMatches
        {
            get { return m_ExactMatches; }
        }

        public int PartialMatches
        {
            get { return m_PartialMatches; }
        }

        private int calculateExactMatches(eGamePins[] i_UserGuess, eGamePins[] i_SecretSequence)
        {
            int exactMatches = 0;

            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                if (i_UserGuess[i] == i_SecretSequence[i])
                {
                    exactMatches++;
                }
            }

            return exactMatches;
        }

        private int calculatePartialMatches(eGamePins[] i_UserGuess, eGamePins[] i_SecretSequence)
        {
            List<eGamePins> secretList = new List<eGamePins>(i_SecretSequence);
            List<eGamePins> guessList = new List<eGamePins>(i_UserGuess);
            int partialMatches = 0;

            for (int i = i_UserGuess.Length - 1; i >= 0; i--)
            {
                if (i_UserGuess[i] == i_SecretSequence[i])
                {
                    secretList.RemoveAt(i);
                    guessList.RemoveAt(i);
                }
            }

            foreach (eGamePins guessPin in guessList)
            {
                if (secretList.Contains(guessPin))
                {
                    partialMatches++;
                }
            }

            return partialMatches;
        }
    }
}


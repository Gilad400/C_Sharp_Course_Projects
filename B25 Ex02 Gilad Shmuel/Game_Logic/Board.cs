using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Board
    {
        private readonly eGamePins[] r_SecretSequence;
        private readonly List<Guess> r_Guesses;
        private readonly int r_MaxGuesses;
        private int m_CurrentGuessNumber;
        private bool m_IsBoardFull;

        public Board(int i_MaxGuesses)
        {
            r_MaxGuesses = i_MaxGuesses;
            r_SecretSequence = generateSecretSequence();
            r_Guesses = new List<Guess>(i_MaxGuesses);
            m_CurrentGuessNumber = 0;
            m_IsBoardFull = false;
        }

        public eGamePins[] SecretSequence
        {
            get { return r_SecretSequence; }
        }

        public List<Guess> Guesses
        {
            get { return r_Guesses; }
        }

        public int MaxGuesses
        {
            get { return r_MaxGuesses; }
        }

        public int CurrentGuessNumber
        {
            get { return m_CurrentGuessNumber; }
        }

        public bool IsBoardFull
        {
            get { return m_IsBoardFull; }
        }

        public bool AddGuess(eGamePins[] i_UserGuess)
        {
            bool AddedGuessSuccess = false;

            if (!m_IsBoardFull)
            {
                Guess newGuess = new Guess(i_UserGuess, r_SecretSequence);

                r_Guesses.Add(newGuess);
                m_CurrentGuessNumber = r_Guesses.Count;
                m_IsBoardFull = (r_Guesses.Count >= r_MaxGuesses);
                AddedGuessSuccess = true;
            }

            return AddedGuessSuccess;
        }

        public bool IsLastGuessCorrect()
        {
            bool isCorrect = true;

            if (r_Guesses.Count > 0)
            {
                Guess lastGuess = r_Guesses[r_Guesses.Count - 1];

                isCorrect = (lastGuess.ExactMatches == GameConstants.SequenceLength);
            }

            return isCorrect;
        }

        private eGamePins[] generateSecretSequence()
        {
            eGamePins[] allPins = (eGamePins[])Enum.GetValues(typeof(eGamePins));
            List<eGamePins> availablePins = new List<eGamePins>(allPins);
            Random r_Random = new Random();
            eGamePins[] sequence = new eGamePins[GameConstants.SequenceLength];

            for (int i = 0; i < GameConstants.SequenceLength; i++)
            {
                int randomIndex = r_Random.Next(availablePins.Count);
                sequence[i] = availablePins[randomIndex];
                availablePins.RemoveAt(randomIndex);
            }

            return sequence;
        }
    }
}

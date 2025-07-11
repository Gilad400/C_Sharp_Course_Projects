using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Game
    {
        private Board m_GameBoard;
        private bool m_IsGameOver;
        private bool m_IsGameWon;
        private int m_CurrentRound;

        public Game(int i_MaxGuesses)
        {
            m_GameBoard = new Board(i_MaxGuesses);
            m_IsGameOver = false;
            m_IsGameWon = false;
            m_CurrentRound = 1;
        }

        public Board GameBoard
        {
            get { return m_GameBoard; }
        }

        public bool IsGameOver
        {
            get { return m_IsGameOver; }
        }

        public bool IsGameWon
        {
            get { return m_IsGameWon; }
        }

        public int CurrentRound
        {
            get { return m_CurrentRound; }
        }

        public bool MakeGuess(eGamePins[] i_UserGuess)
        {
            bool makeGuessSuccess = false;

            if (!m_IsGameOver)
            {
                if (m_GameBoard.AddGuess(i_UserGuess))
                {
                    m_CurrentRound++;
                    if (m_GameBoard.IsLastGuessCorrect())
                    {
                        m_IsGameWon = true;
                        m_IsGameOver = true;
                    }
                    else if (m_GameBoard.IsBoardFull)
                    {
                        m_IsGameOver = true;
                    }

                    makeGuessSuccess = true;
                }
            }

            return makeGuessSuccess;
        }

        public static bool IsLogicValidGuess(eGamePins[] i_Guess)
        {
            bool isValid = false;

            if (i_Guess != null && i_Guess.Length == GameConstants.SequenceLength)
            {
                bool hasDuplicates = false;

                for (int i = 0; i < i_Guess.Length && !hasDuplicates; i++)
                {
                    for (int j = i + 1; j < i_Guess.Length; j++)
                    {
                        if (i_Guess[i] == i_Guess[j])
                        {
                            hasDuplicates = true;
                            break;
                        }
                    }
                }

                isValid = !hasDuplicates;
            }

            return isValid;
        }

        public static bool IsLogicValidMaxGuess(int i_MaxGuesses)
        {
            return i_MaxGuesses <= GameConstants.MaxGuesses && i_MaxGuesses >= GameConstants.MinGuesses;
        }
    }
}




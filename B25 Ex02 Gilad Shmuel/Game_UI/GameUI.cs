using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_UI
{
    public class GameUI
    {
        private const string k_QuitCommand = "Q";
        private const string k_YesAnswer = "Y";
        private const string k_NoAnswer = "N";
        private const char k_HiddenChar = '#';
        private const char k_ExactMatchChar = 'V';
        private const char k_PartialMatchChar = 'X';
        private Game m_CurrentGame;
        private bool m_UserWantsToExit;

        public void RunGame()
        {
            bool wantToPlayAgain = true;

            while (wantToPlayAgain && !m_UserWantsToExit)
            {
                playGameRound();
                if (m_UserWantsToExit)
                {
                    break;
                }

                wantToPlayAgain = askToPlayAgain();
                if (wantToPlayAgain)
                {
                    Console.Clear();
                }
            }

            showGoodbyeMessage();
        }

        private void playGameRound()
        {
            int maxGuesses = getMaxGuessesFromUser();
            bool gameEnded = false;

            m_CurrentGame = new Game(maxGuesses);
            displayBoard();
            while (!gameEnded && !m_UserWantsToExit)
            {
                eGamePins[] userGuess = getGuessFromUser();

                if (userGuess == null) 
                {
                    m_UserWantsToExit = true;
                    break;
                }

                m_CurrentGame.MakeGuess(userGuess);
                displayBoard();
                if (m_CurrentGame.IsGameWon)
                {
                    showWinMessage();
                    gameEnded = true;
                }
                else if (m_CurrentGame.IsGameOver)
                {
                    showLoseMessage();
                    gameEnded = true;
                }
            }
        }

        private int getMaxGuessesFromUser()
        {
            int maxGusses = 0;
            bool validInput = false;

            Console.WriteLine("Please enter the maximum number of guesses (4-10):");
            while (!validInput)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out maxGusses))
                {
                    if (Game.IsLogicValidMaxGuess(maxGusses))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Semantic error! Number must be between 4 and 10, please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Syntactic error! Please enter a valid number and try again");
                }
            }

            return maxGusses;
        }

        private eGamePins[] getGuessFromUser()
        {
            eGamePins[] guess = null;
            bool validInput = false;

            Console.WriteLine("Please type your next guess (A B C D) or 'Q' to quit: ");
            while (!validInput)
            {
                string userInput = Console.ReadLine();

                if (userInput == k_QuitCommand)
                {
                    guess = null;
                    break;
                }

                if (userInput.Length != GameConstants.SequenceLength)
                {
                    Console.WriteLine("Syntactic error! Please enter exactly 4 characters and try again");
                }
                else
                {
                    guess = PinMapper.ParseGuessStringToGamePin(userInput);
                    if (guess == null)
                    {
                        Console.WriteLine("Semantic error! Please use only letters A-H and try again");
                    }
                    else if (!Game.IsLogicValidGuess(guess))
                    {
                        Console.WriteLine("Syntactic error! Please enter each letter only once and try again");
                    }
                    else
                    {
                        validInput = true;
                    }
                }     
            }

            return guess;
        }

        private bool askToPlayAgain()
        {
            string answer = string.Empty;
            bool validInput = false;

            Console.Write($"Would you like to start a new game? ({k_YesAnswer}/{k_NoAnswer}): ");
            while (!validInput)
            {
                answer = Console.ReadLine();
                if (answer == k_YesAnswer || answer == k_NoAnswer)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input! Please enter {k_YesAnswer} or {k_NoAnswer}.");
                }
            }

            return answer == k_YesAnswer;
        }

        private void displayBoard()
        {
            StringBuilder boardDisplay = new StringBuilder();

            Console.Clear();
            boardDisplay.AppendLine("Current Board Status:");
            boardDisplay.AppendLine();
            boardDisplay.AppendLine("|Pins:    |Result:|");
            boardDisplay.AppendLine("|=========|=======|");
            for (int i = 0; i <= m_CurrentGame.GameBoard.MaxGuesses; i++)
            {
                boardDisplay.AppendLine(buildBoardRow(i));
                boardDisplay.AppendLine("|=========|=======|");
            }

            Console.Write(boardDisplay.ToString());
        }

        private string buildBoardRow(int i_RowIndex)
        {
            StringBuilder row = new StringBuilder();

            row.Append("| ");
            if (i_RowIndex == 0)
            {
                if (m_CurrentGame.IsGameOver && !m_CurrentGame.IsGameWon)
                {
                    appendFormattedSequence(row, m_CurrentGame.GameBoard.SecretSequence);
                }
                else
                {
                    appendHiddenSequence(row);
                }
            }
            else if (i_RowIndex <= m_CurrentGame.GameBoard.Guesses.Count)
            {
                int guessIndex = i_RowIndex - 1;

                appendFormattedSequence(row, m_CurrentGame.GameBoard.Guesses[guessIndex].GuessSequence);
            }
            else
            {
                appendEmptySpaces(row);
            }

            row.Append(" |");
            if (i_RowIndex == 0)
            {
                appendEmptySpaces(row);
            }
            else if (i_RowIndex <= m_CurrentGame.GameBoard.Guesses.Count)
            {
                int resultIndex = i_RowIndex - 1;
                string feedback = buildFeedbackString(m_CurrentGame.GameBoard.Guesses[resultIndex]);
                int spacesToAdd = (GameConstants.SequenceLength * 2 - 1) - feedback.Length;

                row.Append(feedback);
                for (int j = 0; j < spacesToAdd; j++)
                {
                    row.Append(" ");
                }
            }
            else
            {
                appendEmptySpaces(row);
            }

            row.Append("|");

            return row.ToString();
        }

        private void appendFormattedSequence(StringBuilder io_StringBuilder, eGamePins[] i_Sequence)
        {
            for (int j = 0; j < i_Sequence.Length; j++)
            {
                io_StringBuilder.Append(PinMapper.PinToChar(i_Sequence[j]));
                if (j < GameConstants.SequenceLength - 1)
                {
                    io_StringBuilder.Append(" ");
                }
            }
        }

        private void appendHiddenSequence(StringBuilder io_StringBuilder)
        {
            for (int j = 0; j < GameConstants.SequenceLength; j++)
            {
                io_StringBuilder.Append(k_HiddenChar);
                if (j < GameConstants.SequenceLength - 1)
                {
                    io_StringBuilder.Append(" ");
                }
            }
        }

        private void appendEmptySpaces(StringBuilder io_StringBuilder)
        {
            for (int j = 0; j < GameConstants.SequenceLength; j++)
            {
                io_StringBuilder.Append(" ");
                if (j < GameConstants.SequenceLength - 1)
                {
                    io_StringBuilder.Append(" ");
                }
            }
        }

        private string buildFeedbackString(Guess i_Guess)
        {
            StringBuilder feedback = new StringBuilder();

            for (int i = 0; i < i_Guess.ExactMatches; i++)
            {
                feedback.Append(k_ExactMatchChar);
                if (i < i_Guess.ExactMatches - 1 || i_Guess.PartialMatches > 0)
                {
                    feedback.Append(" ");
                }
            }

            for (int i = 0; i < i_Guess.PartialMatches; i++)
            {
                feedback.Append(k_PartialMatchChar);
                if (i < i_Guess.PartialMatches - 1)
                {
                    feedback.Append(" ");
                }
            }

            return feedback.ToString();
        }

        private void showWinMessage()
        {
            Console.WriteLine($"You guessed after {m_CurrentGame.CurrentRound - 1} steps!");
        }

        private void showLoseMessage()
        {
            Console.WriteLine("No more guesses allowed. You Lost.");
        }

        private void showGoodbyeMessage()
        {
            Console.WriteLine("Goodbye!");
        }
    }
}

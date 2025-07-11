using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Logic;
using static System.Net.Mime.MediaTypeNames;

namespace Game_UI
{
    internal class GameBoardForm : Form
    {
        private readonly Game r_Game;
        private Button[] m_SecretButtons;
        private GuessButton[] m_GuessButtons;
        private ArrowButton[] m_ArrowButtons;
        private Button[] m_ResultButtons;
        private const int k_ButtonSize = 50;
        private const int k_ButtonSpacing = 5;
        private const int k_FormPadding = 20;
        private const int k_ArrowButtonWidth = 50;
        private const int k_ResultButtonSize = 20;
        private const int k_SectionSpacing = 15;

        public GameBoardForm(Game i_Game)
        {
            r_Game = i_Game;
            setupFormProperties();
            initControls();
        }

        private void setupFormProperties()
        {
            Text = "Bool Pgia";
            StartPosition = FormStartPosition.CenterScreen;
            int formWidth = (2 * k_FormPadding) + (GameConstants.SequenceLength * k_ButtonSize) +
                          ((GameConstants.SequenceLength - 1) * k_ButtonSpacing) + k_SectionSpacing +
                          k_ArrowButtonWidth + k_SectionSpacing + (2 * k_ResultButtonSize) + k_ButtonSpacing + 15;

            int formHeight = (2 * k_FormPadding) + k_ButtonSize + k_SectionSpacing +
                           (r_Game.GameBoard.MaxGuesses * (k_ButtonSize + k_ButtonSpacing)) + 30;
            Size = new Size(formWidth, formHeight);
        }

        private void initControls()
        {
            initSecretButtons();
            initGuessButtons();
            initArrowButtons();
            initResultButtons();
        }

        private void initSecretButtons()
        {
            m_SecretButtons = new Button[GameConstants.SequenceLength];
            for (int i = 0; i < GameConstants.SequenceLength; i++)
            {
                m_SecretButtons[i] = new Button();
                m_SecretButtons[i].Size = new Size(k_ButtonSize, k_ButtonSize);
                m_SecretButtons[i].Location = new Point(
                    k_FormPadding + (i * (k_ButtonSize + k_ButtonSpacing)), k_FormPadding);
                m_SecretButtons[i].BackColor = Color.Black;
                m_SecretButtons[i].Enabled = false;
                Controls.Add(m_SecretButtons[i]);
            }
        }

        private void initGuessButtons()
        {
            int totalGuessButtons = r_Game.GameBoard.MaxGuesses * GameConstants.SequenceLength;

            m_GuessButtons = new GuessButton[totalGuessButtons];
            for (int i = 0; i < totalGuessButtons; i++)
            {
                int row = i / GameConstants.SequenceLength;
                int col = i % GameConstants.SequenceLength;

                m_GuessButtons[i] = new GuessButton(row, col);
                m_GuessButtons[i].Size = new Size(k_ButtonSize, k_ButtonSize);
                m_GuessButtons[i].Location = new Point(
                    k_FormPadding + (col * (k_ButtonSize + k_ButtonSpacing)),
                    k_FormPadding + k_ButtonSize + k_SectionSpacing + (row * (k_ButtonSize + k_ButtonSpacing))
                );
                m_GuessButtons[i].Click += guessButtons_Click;
                m_GuessButtons[i].Enabled = (row == 0);
                Controls.Add(m_GuessButtons[i]);
            }
        }

        private void guessButtons_Click(object sender, EventArgs e)
        {
            GuessButton clickedButton = sender as GuessButton;
            ColorSelectionForm colorForm = new ColorSelectionForm(ColorPinMapper.Colors);

            if (colorForm.ShowDialog() == DialogResult.OK)
            {
                clickedButton.SetColor(colorForm.ChosenColor);
                checkRowCompletion(clickedButton.Row);
            }
        }

        private void checkRowCompletion(int i_Row)
        {
            bool isRowComplete = true;

            for (int col = 0; col < GameConstants.SequenceLength; col++)
            {
                int buttonIndex = getButtonIndex(i_Row, col);
                if (!m_GuessButtons[buttonIndex].IsColorSet)
                {
                    isRowComplete = false;
                    break;
                }
            }

            m_ArrowButtons[i_Row].Enabled = isRowComplete;
        }

        private void initArrowButtons()
        {
            m_ArrowButtons = new ArrowButton[r_Game.GameBoard.MaxGuesses];
            int arrowButtonXPosition = k_FormPadding + (GameConstants.SequenceLength * k_ButtonSize) +
                             ((GameConstants.SequenceLength - 1) * k_ButtonSpacing) + k_SectionSpacing;
            for (int row = 0; row < r_Game.GameBoard.MaxGuesses; row++)
            {
                m_ArrowButtons[row] = new ArrowButton(row);
                m_ArrowButtons[row].Size = new Size(k_ArrowButtonWidth, k_ButtonSize / 2);
                m_ArrowButtons[row].Location = new Point(
                    arrowButtonXPosition,
                    k_FormPadding + k_ButtonSize + k_SectionSpacing + (row * (k_ButtonSize + k_ButtonSpacing) + k_ButtonSize / 4)
                );
                m_ArrowButtons[row].Click += arrowButtons_Click;
                m_ArrowButtons[row].Enabled = false; 
                Controls.Add(m_ArrowButtons[row]);
            }
        }

        private void arrowButtons_Click(object sender, EventArgs e)
        {
            ArrowButton clickedArrow = sender as ArrowButton;
            int row = clickedArrow.Row;
            eGamePins[] guess = new eGamePins[GameConstants.SequenceLength];

            for (int col = 0; col < GameConstants.SequenceLength; col++)
            {
                int buttonIndex = getButtonIndex(row, col);
                Color buttonColor = m_GuessButtons[buttonIndex].BackColor;
                guess[col] = ColorPinMapper.ColorToPin(buttonColor);
            }

            if (Game.IsLogicValidGuess(guess))
            {
                r_Game.MakeGuess(guess);
                displayGuessResult(row);
                clickedArrow.Enabled = false;
                for (int col = 0; col < GameConstants.SequenceLength; col++)
                {
                    int buttonIndex = getButtonIndex(row, col);
                    m_GuessButtons[buttonIndex].Enabled = false;
                }

                if (r_Game.IsGameOver)
                {
                    handleGameOver();
                }
                else
                {
                    int nextRow = row + 1;

                    for (int col = 0; col < GameConstants.SequenceLength; col++)
                    {
                        int buttonIndex = getButtonIndex(nextRow, col);

                        m_GuessButtons[buttonIndex].Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid guess! You cannot use the same color twice in one row",
                                "Invalid Guess",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);  
            }
        }

        private int getButtonIndex(int i_Row, int i_Col)
        {
            return (i_Row * GameConstants.SequenceLength) + i_Col;
        }

        private void handleGameOver()
        {
            eGamePins[] secretSequence = r_Game.GameBoard.SecretSequence;

            for (int i = 0; i < GameConstants.SequenceLength; i++)
            {
                m_SecretButtons[i].BackColor = ColorPinMapper.PinToColor(secretSequence[i]);
            }
        }

        private void initResultButtons()
        {
            int totalResultButtons = r_Game.GameBoard.MaxGuesses * GameConstants.SequenceLength;

            m_ResultButtons = new Button[totalResultButtons];
            int resultButtonsXPosition = k_FormPadding + (GameConstants.SequenceLength * k_ButtonSize) +
                               ((GameConstants.SequenceLength - 1) * k_ButtonSpacing) + k_SectionSpacing +
                               k_ArrowButtonWidth + k_SectionSpacing;
            for (int i = 0; i < totalResultButtons; i++)
            {
                int row = i / GameConstants.SequenceLength;
                int col = i % GameConstants.SequenceLength;

                m_ResultButtons[i] = new Button();
                m_ResultButtons[i].Size = new Size(k_ResultButtonSize, k_ResultButtonSize);
                int buttonCol = col % 2;
                int buttonRow = col / 2;
                m_ResultButtons[i].Location = new Point(
                    resultButtonsXPosition + (buttonCol * (k_ResultButtonSize + k_ButtonSpacing)),
                    k_FormPadding + k_ButtonSize + k_SectionSpacing + (row * (k_ButtonSize + k_ButtonSpacing)) +
                    (buttonRow * (k_ResultButtonSize + k_ButtonSpacing))
                );
                m_ResultButtons[i].Enabled = false;
                Controls.Add(m_ResultButtons[i]);
            }
        }

        private void displayGuessResult(int i_Row)
        {
            Guess lastGuess = r_Game.GameBoard.Guesses[r_Game.GameBoard.Guesses.Count - 1];
            int exactMatches = lastGuess.ExactMatches;
            int partialMatches = lastGuess.PartialMatches;
            int resultIndex = 0;

            for (int i = 0; i < exactMatches; i++)
            {
                int buttonIndex = getButtonIndex(i_Row, resultIndex);

                m_ResultButtons[buttonIndex].BackColor = Color.Black;
                resultIndex++;
            }

            for (int i = 0; i < partialMatches; i++)
            {
                int buttonIndex = getButtonIndex(i_Row, resultIndex);

                m_ResultButtons[buttonIndex].BackColor = Color.Yellow;
                resultIndex++;
            }
        }
    }
}

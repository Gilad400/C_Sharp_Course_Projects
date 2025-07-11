using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;
using System.Windows.Forms;

namespace Game_UI
{
    internal class GameManager
    {
        private Game m_Game;
        private int m_NumberOfGuesses;

        public void Play()
        {
            if (getGameSettings())
            {
                startGame();
            }
        }

        private bool getGameSettings()
        {
            GameSetupForm gameSetupForm = new GameSetupForm();
            bool settingsSuccess = false;

            if (gameSetupForm.ShowDialog() == DialogResult.OK)
            {
                m_NumberOfGuesses = gameSetupForm.NumberOfGuesses;
                settingsSuccess = true;
            }

            return settingsSuccess;
        }

        private void startGame()
        {
            m_Game = new Game(m_NumberOfGuesses);
            GameBoardForm gameBoardForm = new GameBoardForm(m_Game);
            gameBoardForm.ShowDialog();
        }
    }
}

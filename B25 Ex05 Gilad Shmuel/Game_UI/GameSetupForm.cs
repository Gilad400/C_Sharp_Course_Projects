using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Logic;

namespace Game_UI
{
    internal class GameSetupForm : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonNumberOfGuesses;
        private int m_NumberOfGuesses;
        private const int k_ButtonNumberOfGuessesWidth = 200;
        private const int k_ButtonStartWidth = 85;
        private const int k_ButtonHeight = 28;
        private const int k_TopMargin = 18;
        private const int k_LeftMargin = 18;
        private const int k_VerticalSpacing = 55;
        private const int k_FormWidth = 250;
        private const int k_FormHeight = 150;

        public GameSetupForm()
        {
            m_NumberOfGuesses = GameConstants.MinGuesses;
            setupFormProperties();
            initControls();
        }

        public int NumberOfGuesses
        {
            get { return m_NumberOfGuesses; }
        }

        private void setupFormProperties()
        {
            Size = new Size(k_FormWidth, k_FormHeight);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bool Pgia";
        }

        private void initControls()
        {
            m_ButtonNumberOfGuesses = new Button();
            m_ButtonNumberOfGuesses.Text = string.Format("Number of Chances: {0}", m_NumberOfGuesses);
            m_ButtonNumberOfGuesses.Location = new Point(k_LeftMargin, k_TopMargin);
            m_ButtonNumberOfGuesses.Size = new Size(k_ButtonNumberOfGuessesWidth, k_ButtonHeight);
            m_ButtonNumberOfGuesses.Click += buttonNumberOfGuesses_Click;
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Location = new Point(m_ButtonNumberOfGuesses.Right - k_ButtonStartWidth, k_TopMargin + k_VerticalSpacing);
            m_ButtonStart.Size = new Size(k_ButtonStartWidth, k_ButtonHeight);
            m_ButtonStart.Click += buttonStart_Click;
            Controls.AddRange(new Control[] { m_ButtonNumberOfGuesses, m_ButtonStart });
        }

        private void buttonNumberOfGuesses_Click(object sender, EventArgs e)
        {
            if (m_NumberOfGuesses >= GameConstants.MaxGuesses)
            {
                m_NumberOfGuesses = GameConstants.MinGuesses;
            }
            else
            {
                m_NumberOfGuesses++;
            }

            m_ButtonNumberOfGuesses.Text = string.Format("Number of Chances: {0}", m_NumberOfGuesses);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

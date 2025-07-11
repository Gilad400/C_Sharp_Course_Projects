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
    internal class ColorSelectionForm : Form
    {
        private Color m_ChosenColor;
        private const int k_ButtonSpacing = 5;
        private const int k_FormPadding = 20;
        private const int k_ButtonWidth = 50;  
        private const int k_ButtonHeight = 50;

        public ColorSelectionForm(List<Color> i_Colors)
        {
            setupFormProperties(i_Colors.Count);
            initControls(i_Colors);
        }

        public Color ChosenColor
        {
            get { return m_ChosenColor; }
        }

        private void setupFormProperties(int i_NumOfColors)
        {
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pick A Color:";
            int colorsPerRow = i_NumOfColors / 2;
            int numberOfRows = (i_NumOfColors + colorsPerRow - 1) / colorsPerRow;
            int formWidth = (2 * k_FormPadding) + (colorsPerRow * k_ButtonWidth) + ((colorsPerRow - 1) * k_ButtonSpacing) + 15;
            int formHeight = (2 * k_FormPadding) + (numberOfRows * k_ButtonHeight) + ((numberOfRows - 1) * k_ButtonSpacing) + 30;
            Size = new Size(formWidth, formHeight);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void initControls(List<Color> i_AvailableColors)
        {
            int k_ColorsPerRow = i_AvailableColors.Count / 2;
            int colorIndex = 0;

            foreach (Color color in i_AvailableColors)
            {
                Button buttonColor = new Button();

                buttonColor.BackColor = color;
                buttonColor.Size = new Size(k_ButtonWidth, k_ButtonHeight);
                int row = colorIndex / k_ColorsPerRow;
                int col = colorIndex % k_ColorsPerRow;
                buttonColor.Location = new Point(
                    k_FormPadding + (col * (k_ButtonWidth + k_ButtonSpacing)),
                    k_FormPadding + (row * (k_ButtonHeight + k_ButtonSpacing))
                );
                buttonColor.Click += buttonColor_Click;
                Controls.Add(buttonColor);
                colorIndex++;
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            m_ChosenColor = (sender as Button).BackColor;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

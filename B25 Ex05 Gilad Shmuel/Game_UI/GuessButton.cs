using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_UI
{
    internal class GuessButton : Button
    {
        private readonly int r_Row;
        private readonly int r_Column;
        private bool m_IsColorSet;

        public GuessButton(int i_Row, int i_Column)
        {
            r_Row = i_Row;
            r_Column = i_Column;
            m_IsColorSet = false;
        }

        public int Row
        {
            get { return r_Row; }
        }

        public int Column
        {
            get { return r_Column; }
        }

        public bool IsColorSet
        {
            get { return m_IsColorSet; }
        }

        public void SetColor(Color i_Color)
        {
            BackColor = i_Color;
            m_IsColorSet = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_UI
{
    internal class ArrowButton : Button
    {
        private readonly int r_Row;

        public ArrowButton(int i_Row)
        {
            r_Row = i_Row;
            Text = "-->>";
        }

        public int Row
        {
            get { return r_Row; }
        }
    }
}

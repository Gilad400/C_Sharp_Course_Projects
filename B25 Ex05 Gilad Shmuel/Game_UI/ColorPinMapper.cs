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
    internal static class ColorPinMapper
    {
        private static readonly List<Color> sr_Colors = new List<Color>
        {
            Color.Purple,   
            Color.Red,      
            Color.Green,    
            Color.Cyan,     
            Color.Blue,     
            Color.Yellow,   
            Color.Brown,    
            Color.White     
        };

        public static List<Color> Colors
        {
            get { return sr_Colors; }
        }

        public static Color PinToColor(eGamePins i_Pin)
        {
            return sr_Colors[(int)i_Pin];
        }

        public static eGamePins ColorToPin(Color i_Color)
        {
            eGamePins gamePin = eGamePins.Pin1;

            for (int i = 0; i < sr_Colors.Count; i++)
            {
                if (sr_Colors[i] == i_Color)
                {
                    gamePin = (eGamePins)i;
                }
            } 

            return gamePin;
        }
    }
}

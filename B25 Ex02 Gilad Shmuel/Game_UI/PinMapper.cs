using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_UI
{
    public class PinMapper
    {
        public static char PinToChar(eGamePins i_Pin)
        {
            char result = 'A';

            switch (i_Pin)
            {
                case eGamePins.Pin1:
                    result = 'A';
                    break;
                case eGamePins.Pin2:
                    result = 'B';
                    break;
                case eGamePins.Pin3:
                    result = 'C';
                    break;
                case eGamePins.Pin4:
                    result = 'D';
                    break;
                case eGamePins.Pin5:
                    result = 'E';
                    break;
                case eGamePins.Pin6:
                    result = 'F';
                    break;
                case eGamePins.Pin7:
                    result = 'G';
                    break;
                case eGamePins.Pin8:
                    result = 'H';
                    break;
            }

            return result;
        }

        public static eGamePins CharToPin(char i_Char)
        {
            eGamePins result = eGamePins.Pin1;

            switch (char.ToUpper(i_Char))
            {
                case 'A':
                    result = eGamePins.Pin1;
                    break;
                case 'B':
                    result = eGamePins.Pin2;
                    break;
                case 'C':
                    result = eGamePins.Pin3;
                    break;
                case 'D':
                    result = eGamePins.Pin4;
                    break;
                case 'E':
                    result = eGamePins.Pin5;
                    break;
                case 'F':
                    result = eGamePins.Pin6;
                    break;
                case 'G':
                    result = eGamePins.Pin7;
                    break;
                case 'H':
                    result = eGamePins.Pin8;
                    break;
            }

            return result;
        }

        public static eGamePins[] ParseGuessStringToGamePin(string i_GuessString)
        {
            eGamePins[] guess = new eGamePins[GameConstants.SequenceLength];
            bool isValid = true;

            for (int i = 0; i < i_GuessString.Length && isValid; i++)
            {
                char currentChar = i_GuessString[i];

                if (currentChar >= 'A' && currentChar <= 'H')
                {
                    guess[i] = CharToPin(currentChar);
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid ? guess : null;
        }
    }
}

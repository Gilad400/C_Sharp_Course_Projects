using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        private static int s_currentNumberToPrint = 1;
        public static void Main()
        {
            PrintDynamicNumberTree(7);
        }

        public static void PrintDynamicNumberTree(int i_Height, int i_CurrentLine = 0)
        {
            if (i_CurrentLine >= i_Height)
            {
                s_currentNumberToPrint = 1;
                return;
            }

            char rowLetter = (char)('A' + i_CurrentLine);
            Console.Write($"{rowLetter} ");

            if (i_CurrentLine < i_Height - 2)
            {
                PrintNumbersForRows(i_CurrentLine, i_Height);
                Console.WriteLine();
            }
            else
            {
                PrintTrunk(i_Height);
                Console.WriteLine();
            }

            PrintDynamicNumberTree(i_Height, i_CurrentLine + 1);
        }

        public static void PrintNumbersForRows(int i_RowIndex, int i_Height)
        {
            int numbersCount = 2 * i_RowIndex + 1;
            int maxWidth = (2 * (i_Height - 2) + 1) * 2 - 1;
            int currentWidth = numbersCount * 2 - 1;
            int leadingSpaces = (maxWidth - currentWidth) / 2;

            for (int i = 0; i < leadingSpaces; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write($"{s_currentNumberToPrint} ");
                s_currentNumberToPrint++;
                s_currentNumberToPrint = s_currentNumberToPrint == 10 ? 1 : s_currentNumberToPrint;
            }
        }

        public static void PrintTrunk(int i_Height)
        {
            int maxWidth = (2 * (i_Height - 2) + 1) * 2 - 1;
            int trunkWidth = 3;
            int leadingSpaces = (maxWidth - trunkWidth) / 2;

            for (int i = 0; i < leadingSpaces; i++)
            {
                Console.Write(" ");
            }

            Console.Write($"|{s_currentNumberToPrint}|");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            string heightInputStr = "";

            Console.WriteLine("Enter desired height of the tree, then press 'enter'");
            while (!IsValidHeight(heightInputStr = Console.ReadLine()))
            {
                Console.WriteLine("The height is not valid. Please try again");
            }

            int heightInput = int.Parse(heightInputStr);
            Ex01_02.Program.PrintDynamicNumberTree(heightInput);
        }

        public static bool IsValidHeight(string i_HeightInput)
        {
            bool isValid = false;

            if (int.TryParse(i_HeightInput, out int treeHeight))
            {
                isValid = (treeHeight >= 4 && treeHeight <= 15);
            }

            return isValid;
        }
    }
}
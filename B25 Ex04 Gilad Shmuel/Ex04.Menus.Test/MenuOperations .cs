using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal static class MenuOperations
    {
        internal static void ShowVersion_PerformAction()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
            Console.WriteLine();
        }

        internal static void CountLowercaseLetters_PerformAction()
        {
            int numberOfLowercaseLetters = 0;

            Console.WriteLine("Please write your text:");
            string userInput = Console.ReadLine();
            foreach (char c in userInput)
            {
                if (char.IsLower(c))
                {
                    numberOfLowercaseLetters++;
                }
            }

            Console.WriteLine("There are {0} lowercase letters in your text", numberOfLowercaseLetters);
            Console.WriteLine();
        }

        internal static void ShowCurrentDate_PerformAction()
        {
            Console.WriteLine("Current Date is {0}", DateTime.Now.Date.ToShortDateString());
            Console.WriteLine();
        }

        internal static void ShowCurrentTime_PerformAction()
        {
            Console.WriteLine("Current Time is {0}", DateTime.Now.ToString("HH:mm"));
            Console.WriteLine();
        }
    }
}

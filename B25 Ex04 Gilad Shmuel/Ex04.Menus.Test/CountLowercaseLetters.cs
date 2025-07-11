using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountLowercaseLetters : IMenuItem
    {
        string IMenuItem.Title
        {
            get { return "Count Lowercase Letters"; }
        }

        void IMenuItem.Perform()
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
    }
}

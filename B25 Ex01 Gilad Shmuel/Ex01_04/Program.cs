using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string inputString = "";
            StringBuilder solution = new StringBuilder();

            Console.WriteLine("Please enter a string of 12 characters, then press 'enter'");
            while (!IsValidString(inputString = Console.ReadLine()))
            {
                Console.WriteLine("The string is not valid. Please try again");
            }

            solution.AppendLine($"Is palindrone: {(IsPalindrome(inputString.ToLower()) ? "Yes" : "No")}");
            if (long.TryParse(inputString, out long inputInInt))
            {
                if (IsDivideBy3(inputInInt))
                {
                    solution.AppendLine("Is divisible by 3 without remainder: Yes");
                }
            }

            if (IsEnglishWord(inputString))
            {
                solution.AppendLine($"Number of uppercase letters: {NumOfUpperCases(inputString)}");
                solution.AppendLine($"Is in alphabetical order: {(IsAlphabetical(inputString) ? "Yes" : "No")}");
            }

            Console.WriteLine(solution.ToString());
        }

        public static bool IsValidString(string i_InputString)
        {
            return i_InputString.Length == 12;
        }

        public static bool IsPalindrome(string i_InputString)
        {
            bool isPalindrom = false;

            if (i_InputString.Length == 0 || i_InputString.Length == 1)
            {
                isPalindrom = true;
            }
            else if (i_InputString[0] == i_InputString[i_InputString.Length - 1])
            {
                isPalindrom = IsPalindrome(i_InputString.Substring(1, i_InputString.Length - 2));
            }

            return isPalindrom;
        }

        public static bool IsDivideBy3(long i_InputInInt)
        {
            return (i_InputInInt % 3) == 0;
        }

        public static bool IsEnglishWord(string i_InputString)
        {
            bool isWord = true;

            foreach (char currentCharInWord in i_InputString)
            {
                if (!char.IsLetter(currentCharInWord))
                {
                    isWord = false;
                    break;
                }
            }

            return isWord;
        }

        public static int NumOfUpperCases(string i_InputString)
        {
            int NumOfUpperCasesLetters = 0;

            foreach (char currentCharInWord in i_InputString)
            {
                if (char.IsUpper(currentCharInWord))
                {
                    NumOfUpperCasesLetters++;
                }
            }

            return NumOfUpperCasesLetters;
        }

        public static bool IsAlphabetical (string i_InputString)
        {
            bool isAlphabetical = true;

            for (int indexOfLetter = 0; indexOfLetter < i_InputString.Length - 2; indexOfLetter++)
            {
                if (char.ToLower(i_InputString[indexOfLetter]) > char.ToLower(i_InputString[indexOfLetter + 1]))
                {
                    isAlphabetical = false; 
                    break;
                }
            }

            return isAlphabetical;
        }
    }
}
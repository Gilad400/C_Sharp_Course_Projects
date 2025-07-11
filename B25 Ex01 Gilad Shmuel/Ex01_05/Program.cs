using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            string inputNumberInString = "";
            StringBuilder solution = new StringBuilder();

            Console.WriteLine("Please enter a numbers of 8 digit and press 'enter'");
            while (!IsValidNumber(inputNumberInString = Console.ReadLine()))
            {
                Console.WriteLine("The number is not valid. Please try again");
            }

            solution.AppendLine(CountSmallerThanFirstDigit(inputNumberInString));
            solution.AppendLine(CountDigitsDividedBy3(inputNumberInString));
            solution.AppendLine(DifferenceMaxMinDigit(inputNumberInString));
            solution.AppendLine(MostFrequentDigit(inputNumberInString));
            Console.WriteLine(solution.ToString());
        }

        public static bool IsValidNumber(string i_InputNumberInString)
        {
            return !(i_InputNumberInString.Length != 8 || !int.TryParse(i_InputNumberInString, out int convertedNumber));
        }

        public static string CountSmallerThanFirstDigit(string i_InputNumberInString)
        {
            int counterOfSmallerThanFirstDigit = 0;
            char firstDigit = i_InputNumberInString[0];
            string message = string.Format("Leftmost digit: {0}. Smaller digit from first digit (not include it): ", firstDigit);

            foreach (char currentDigit in i_InputNumberInString.Substring(1))
            {
                if (currentDigit < firstDigit)
                {
                    counterOfSmallerThanFirstDigit++;
                    message += string.Format("{0}, ", currentDigit);
                }
            }

            if (counterOfSmallerThanFirstDigit == 0)
            {
                message += "None";
            }
            else
            {
                message = message.Substring(0, message.Length - 2);
            }
    
            message += string.Format(". Total: {0}.", counterOfSmallerThanFirstDigit);

            return message;
        }

        public static string CountDigitsDividedBy3(string i_InputNumberInString)
        {
            int counterDivideBy3 = 0;
            string message = string.Format("Digits divisible by 3: ");

            foreach (char currentDigit in i_InputNumberInString)
            {
                int currentDigitInInt = int.Parse(currentDigit.ToString());
                if ((currentDigitInInt % 3) == 0)
                {
                    counterDivideBy3++;
                    message += string.Format("{0}, ", currentDigit);
                }
            }

            if (counterDivideBy3 == 0)
            {
                message += "None";
            }
            else
            {
                message = message.Substring(0, message.Length - 2);
            }
            
            message += string.Format(". Total: {0}.", counterDivideBy3);

            return message;
        }

        public static string DifferenceMaxMinDigit(string i_InputNumberInString)
        {
            int maxDigit = int.MinValue;
            int minDigit = int.MaxValue;

            foreach (char currentDigit in i_InputNumberInString)
            {
                int currentDigitInInt = currentDigit - '0';
                maxDigit = Math.Max(maxDigit, currentDigitInInt);
                minDigit = Math.Min(minDigit, currentDigitInInt);
            }

            string message = string.Format("Difference between largest and smallest digit: {0}", maxDigit - minDigit);
            
            return message;
        }

        public static string MostFrequentDigit(string i_InputNumberInString)
        {
            char mostFrequentDigit = '0';
            int counterMostFrequentDigit = 0;

            for (char digit = '0'; digit <= '9'; digit++)
            {
                int counterCurrentFrequentDigit = 0;
                for (int currentIndexInWord = 0; currentIndexInWord < i_InputNumberInString.Length; currentIndexInWord++)
                {
                    if (digit == i_InputNumberInString[currentIndexInWord])
                    {
                        counterCurrentFrequentDigit++;
                    }
                }

                if (counterCurrentFrequentDigit > counterMostFrequentDigit)
                {
                    mostFrequentDigit = digit;
                    counterMostFrequentDigit = counterCurrentFrequentDigit;
                }
            }

            string message = string.Format("Most frequent digit: {0} (appears {1} times)", mostFrequentDigit, counterMostFrequentDigit);

            return message;
        }
    }  
}
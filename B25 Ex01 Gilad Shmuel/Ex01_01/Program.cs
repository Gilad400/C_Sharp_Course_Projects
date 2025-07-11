using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    public class Program
	{
		public static void Main()
		{
			string[] binaryArrayStr = new string[4];
			int[] binaryArrayDecimal = new int[4];
			StringBuilder solution = new StringBuilder();	

            Console.WriteLine("Please enter 4 numbers of 7 digit each. Press 'enter' after each number");
			for (int indexInBinaryArrayStr = 0; indexInBinaryArrayStr < binaryArrayStr.Length; indexInBinaryArrayStr++)
			{
				while (!IsValidNumber(binaryArrayStr[indexInBinaryArrayStr] = Console.ReadLine()))
				{
					Console.WriteLine("The number is not valid. Please try again");
				}
				binaryArrayDecimal[indexInBinaryArrayStr] = BinaryToDecimal(binaryArrayStr[indexInBinaryArrayStr]);
			}

			solution.AppendLine(SortNumbersInDescendingOrder(binaryArrayDecimal));
			solution.AppendLine(CalculateAverageOfDecimalValues(binaryArrayDecimal).ToString());
			solution.AppendLine(FindLongestConsecutiveOnesInBinaryArray(binaryArrayStr));
			solution.AppendLine(CountBitTransitionInBinaryArray(binaryArrayStr));
			solution.AppendLine(FindBinaryWithMostOnes(binaryArrayStr));
			solution.AppendLine(CountTotalNumberOfOnes(binaryArrayStr));
			Console.WriteLine(solution.ToString());
		}

		public static bool IsValidNumber(string i_BinaryNumberStr)
		{
			bool isValidNumber = !(i_BinaryNumberStr.Length != 7 || !IsBinaryNumber(i_BinaryNumberStr));

			return isValidNumber;
		}

		public static bool IsBinaryNumber(string i_BinaryNumberStr)
		{
			bool isBinaryNumber = true;

			foreach (char digit in i_BinaryNumberStr)
			{
				isBinaryNumber = !(digit != '0' && digit != '1');
				if (!isBinaryNumber)
				{
					break;
				}
			}

			return isBinaryNumber;
		}

		public static int BinaryToDecimal(string i_BinaryNumberStr)
		{
			int decimalNumber = 0;
			int power = i_BinaryNumberStr.Length - 1;

			foreach (char digit in i_BinaryNumberStr)
			{
				decimalNumber += (digit - '0') * (int)Math.Pow(2, power);
				power--;
			}

			return decimalNumber;
		}

		public static string SortNumbersInDescendingOrder(int[] io_DecimalArray)
		{
            for (int outerLoopIndex = 0; outerLoopIndex < io_DecimalArray.Length - 1; outerLoopIndex++)
            {
                for (int comparisonIndex = 0; comparisonIndex < io_DecimalArray.Length - 1 - outerLoopIndex; comparisonIndex++)
                {
                    if (io_DecimalArray[comparisonIndex] < io_DecimalArray[comparisonIndex + 1])
                    {
                        int currentNumber = io_DecimalArray[comparisonIndex];
                        io_DecimalArray[comparisonIndex] = io_DecimalArray[comparisonIndex + 1];
                        io_DecimalArray[comparisonIndex + 1] = currentNumber;
                    }
                }
            }
			
			string message = string.Format("Decimal numbers in descending order: {0}, {1}, {2}, {3}",
				io_DecimalArray[0], io_DecimalArray[1], io_DecimalArray[2], io_DecimalArray[3]);

            return message;
        }

		public static string CalculateAverageOfDecimalValues(int[] i_DecimalArray)
		{
			int sumOfDecimalValues = 0;
			foreach (int number in i_DecimalArray)
			{
				sumOfDecimalValues += number;
			}

			float AverageOfDecimalValues = (float)sumOfDecimalValues / i_DecimalArray.Length;
            string message = string.Format("Average: {0}", AverageOfDecimalValues);

            return message;
        }

		public static string FindLongestConsecutiveOnesInBinaryArray(string[] i_BinaryArray)
		{
            int longestSequence = 0;
			string numberWithLongestSequence = "";

            foreach (string number in i_BinaryArray)
			{
				int currentSequence = FindLongestConsecutiveOnesInBinaryNumber(number);
				if (currentSequence > longestSequence)
				{
					longestSequence = currentSequence;
					numberWithLongestSequence = number;
                }
            }

			string message = string.Format("Longest sequence of 1's: {0} (from binary number {1})", longestSequence, numberWithLongestSequence);
			
			return message;
		}

        public static int FindLongestConsecutiveOnesInBinaryNumber(string i_BinaryNumberStr)
        {
			int longestSequence = 0;
            int currentSequence = 0;

            foreach (char digit in i_BinaryNumberStr)
			{
				if (digit == '1')
				{
					currentSequence++;
					longestSequence = Math.Max(longestSequence, currentSequence);
				}
				else
				{
					currentSequence = 0;
				}
			}

			return longestSequence;
        }

		public static string CountBitTransitionInBinaryArray(string[] i_BinaryArray)
		{
			string message = "Number of transitions: ";

            foreach (string number in i_BinaryArray)
			{
                int numberOfBitTransition = CountBitTransitionInBinaryNumber(number);
				message += string.Format("{0} ({1}),", numberOfBitTransition, number);
            }

			message = message.Substring(0, message.Length - 1);
            
			return message;
        }

        public static int CountBitTransitionInBinaryNumber(string i_BinaryNumberStr)
        {
			int transitions = 0;

			for (int digitIndex = 1; digitIndex < i_BinaryNumberStr.Length; digitIndex++)
			{
				if (i_BinaryNumberStr[digitIndex] != (i_BinaryNumberStr[digitIndex - 1]))
				{
					transitions++;
				}
			}

			return transitions;
        }

        public static string FindBinaryWithMostOnes(string[] i_BinaryArray)
        {
            int currentCountOfOnes = 0;
            int maxCurrentOfOnes = 0;
            string maxCurrentOfOnesStr = "";

            foreach (string number in i_BinaryArray)
            {
                currentCountOfOnes = CountOnesInBinaryNumber(number);
                if (currentCountOfOnes > maxCurrentOfOnes)
                {
                    maxCurrentOfOnes = currentCountOfOnes;
                    maxCurrentOfOnesStr = number;
                }
            }

            string message = string.Format("The number with the most 1's: {0} (binary: {1})", BinaryToDecimal(maxCurrentOfOnesStr), maxCurrentOfOnesStr);

            return message;
        }

        public static int CountOnesInBinaryNumber(string i_Number)
        {
            int countOfOnes = 0;

            foreach (char digit in i_Number)
            {
                if (digit == '1')
                {
                    countOfOnes++;
                }
            }

            return countOfOnes;
        }

		public static string CountTotalNumberOfOnes(string[] i_BinaryArray)
		{
			int totalNumberOfOnes = 0;

			foreach (string number in i_BinaryArray)
			{
				totalNumberOfOnes += CountOnesInBinaryNumber(number);
			}

			string message = string.Format("Total number of 1's: {0}", totalNumberOfOnes);

			return message;
		}
    }
}
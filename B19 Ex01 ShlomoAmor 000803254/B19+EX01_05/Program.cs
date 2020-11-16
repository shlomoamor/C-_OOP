using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_EX01_05
{
    class Program
    {
        static void Main()
        {
            // object array to store arguements
            object[] argsForFormatter = new object[5];
            int smallestDigit = 0;
            int amountOfThrees = 0;
            int largestDigit = 0;
            int digitsBiggerThanUnit = 0;
            Console.WriteLine("Please enter a integer of size 8: ");
            string inputStr = Console.ReadLine();
            while (true)
            {
                // checking the user input is valid
                if (CheckIntegerValidation(inputStr))
                {
                    smallestDigit = FindSmallestnteger(inputStr);
                    largestDigit = FindLargestInteger(inputStr);
                    amountOfThrees = CountThrees(inputStr);
                    digitsBiggerThanUnit = AmountOfDigitsBiggerThanUnit(inputStr);
                    break;
                }
                else
                {
                    // invalid input
                    Console.WriteLine("Integer must be 8 digits long. Please try again.");
                    inputStr = Console.ReadLine();
                }
            }
            argsForFormatter[0] = inputStr;
            argsForFormatter[1] = smallestDigit;
            argsForFormatter[2] = largestDigit;
            argsForFormatter[3] = amountOfThrees;
            argsForFormatter[4] = digitsBiggerThanUnit;
            string str = string.Format(@"
The inputed integer is: {0} 
The smallest digit is: {1} 
The biggest digit is: {2} 
The amount of threes in the integer is: {3} 
The amount of digits bigger than the unit digit are: {4}. ", argsForFormatter);
            Console.WriteLine(str);
            Console.ReadLine();
        }

        /* Param: string 
         * Return: Boolean value; true if the string is 8 chars and consists of only digits, false otherwise.*/
        private static bool CheckIntegerValidation(string i_str)
        {
            if(i_str.Length != 8)
            {
                return false;
            }
            char digit = ' ';
            for (int i = 0; i < i_str.Length; i++)
            {
                digit = i_str[i];
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }

        /* Param: string 
         * Return: Integer value consisting of the smallest integer in the input string.*/
        private static int FindSmallestnteger(string i_str)
        {
            int currentDigit = 0;
            int smallestDigit = i_str[0] - '0';
            for (int i = 1; i < i_str.Length; i++)
            {
                currentDigit = i_str[i] - '0';
                if (currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
            }
            return smallestDigit;
        }

        /* Param: string 
         * Return: Integer value consisting of the largest integer in the input string.*/
        private static int FindLargestInteger(string i_str)
        {
            int currentDigit = 0;
            int largestDigit = i_str[0] - '0';
            for (int i = 1; i < i_str.Length; i++)
            {
                currentDigit = i_str[i] - '0';
                if (currentDigit > largestDigit)
                {
                    largestDigit = currentDigit;
                }
            }
            return largestDigit;
        }

        /* Param: string 
         * Return: Integer value consisting of the amount of 3's in the input string.*/
        private static int CountThrees(string i_str)
        {
            int currentDigit = 0;
            int amountOfThrees = 0;
            for (int i = 0; i < i_str.Length; i++)
            {
                currentDigit = i_str[i] - '0';
                if (currentDigit == 3)
                {
                    amountOfThrees++;
                }
            }
            return amountOfThrees;
        }

        /* Param: string 
         * Return: Integer value consisting of the amount of digits bigger than the unit's integer in the input string.*/
        private static int AmountOfDigitsBiggerThanUnit(string i_str)
        {
            int currentDigit = 0;
            int unitsDigit = i_str[i_str.Length - 1] - '0';
            int digitsBiggerThanUnit = 0;
            for (int i = 0; i < i_str.Length-1; i++)
            {
                currentDigit = i_str[i] - '0';
                if (currentDigit > unitsDigit)
                {
                    digitsBiggerThanUnit++;
                }
            }
            return digitsBiggerThanUnit;
        }
        
    }
}

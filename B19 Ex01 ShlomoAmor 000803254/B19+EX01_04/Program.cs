using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_EX01_04
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(StringAnaliz());
            System.Console.ReadLine();
        }

        /* Param: void
         * Return: Prints te required information*/
        public static string StringAnaliz()
        {
            System.Console.WriteLine("Please enter a 12 characters string:");
            // simple ReadLine operation:
            string InputStr = System.Console.ReadLine();
            while (!IsValidString(InputStr))
            {
                System.Console.WriteLine("Please enter a valid 12 character string with only digits or letters");
                InputStr = System.Console.ReadLine();
            }
            StringBuilder outputString = new StringBuilder();
            outputString.Append("The string is " + IsPalanidrom(InputStr) + "palanidrom.");
            outputString.AppendLine();
            long inputLong = CheckAndReturnNum(InputStr);
            if (inputLong == -1)
            {
                outputString.Append("There are " + GetNuberOfNonCapital(InputStr) + " lower case letters.");
            }
            else
            {
                outputString.Append("The string is " + IsDividedBy3(inputLong) + "divided by three.");
            }
            return outputString.ToString();
        }

        /* Param: string 
         * Return: Boolean value; true if the string is 12 chars and is a word or a number, false otherwise.*/
        private static bool IsValidString(string i_str)
        {
            return (i_str.Length == 12 && (IsWord(i_str) || CheckAndReturnNum(i_str) != -1));
        }

        /* Param: string 
         * Return: Boolean value; true if the string is a word, false otherwise.*/
        private static bool IsWord(string i_str)
        {
            char currentChar;
            for (int i = 0; i < i_str.Length; i++)
            {
                currentChar = i_str[i];
                if (!System.Char.IsLetter(currentChar))
                {
                    return false;
                }
            }
            return true;

        }

        /* Param: string 
        * Return: long value consisiting of the strings decimal number or -1 if it isnt a number.*/
        private static long CheckAndReturnNum(string i_InputString)
        {
            long returnNum = 0;
            bool isNum = long.TryParse(i_InputString, out returnNum);
            if (!isNum)
            {
                returnNum = -1;
            }
            return returnNum;
        }

        /* Param: string 
        * Return: string value representing if the input string is a palaindrome.*/
        private static string IsPalanidrom(string i_str)
        {
            for (int i = 0; i < i_str.Length / 2; i++)
            {
                if (i_str[i] != i_str[i_str.Length - i - 1])
                {
                    return "not ";
                }
            }
            return "";
        }

        /* Param: long 
         * Return: string value representing if it is divisible by 3.*/
        private static string IsDividedBy3(long i_number)
        {
            if (i_number % 3 != 0)
            {
                return "not ";
            }
            return "";
        }

        /* Param: string 
         * Return: Integer value consisting of the amount of non capital letters.*/
        private static int GetNuberOfNonCapital(string i_str)
        {
            int lowerCaseCounter = 0;
            for (int i = 0; i < i_str.Length / 2; i++)
            {
                if (char.IsLower(i_str[i]))
                {
                    lowerCaseCounter++;
                }
            }
            return lowerCaseCounter;
        }

    }
}

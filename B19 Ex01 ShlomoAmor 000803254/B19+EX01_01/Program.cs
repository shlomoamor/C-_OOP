using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_EX01_01
{
    class Program
    {
        static void Main()
        {
            // object array to store arguements
            object[] argsForFormatter = new object[7];
            int amountOfInputs = 0;
            int amountOfPowerOf2 = 0;
            int strictlyMonotone = 0;
            float amountOfZeros = 0;
            Console.WriteLine("Enter 4 binary sequences each of length 8 when prompted: ");
            while (amountOfInputs < 4)
            {
                string inputStr = Console.ReadLine();
                // checking the user input is valid
                if (CheckBinaryValidation(inputStr))
                {
                    argsForFormatter[amountOfInputs] = BinaryToInt(inputStr);
                    if (IsPowerOf2(inputStr))
                    {
                        amountOfPowerOf2++;
                    }
                    amountOfZeros += CountZeros(inputStr);

                    if (StrictlyIncreasing((int)argsForFormatter[amountOfInputs]))
                    {
                        strictlyMonotone++;
                    }
                    amountOfInputs++;
                }
                else
                {
                    // invalid arguement
                    Console.WriteLine("Binary sequence not valid. Please try again. ");
                }
               
            }
            argsForFormatter[4] = NumberConverter.none + strictlyMonotone;
            argsForFormatter[5] = amountOfZeros / 4;
            argsForFormatter[6] = NumberConverter.none + amountOfPowerOf2;
            //
            string str = string.Format(@" 
The numbers are {0}, {1}, {2}, {3}, {4} of them consists of digits which are stricly monotonically increasing sequences(i.e 345), 
the average amount of zeros is {5}. {6} of them are power of 2. ", argsForFormatter);
            Console.WriteLine(str);
            Console.ReadLine();


        }

        /*Param: string 
        * Return: Integer value consisting of the conversation of the input string to a decimal value.*/
        private static int BinaryToInt(string i_str)
        {
            double sumAmount = 0;
            int digit = 0;
            for (int i = 0; i < i_str.Length; i++)
            {
                int.TryParse(i_str[i_str.Length - i - 1].ToString(), out digit);
                    sumAmount += (double)digit * Math.Pow((double)2, (double)i);
            }
            return (int)sumAmount;
        }

        /*Param: string 
        * Return: Boolean value; if the string consists of only 0's and 1's and is of length 8 returns true, false otherwise.*/
        private static bool CheckBinaryValidation(string i_str)
        {
            if (i_str.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < i_str.Length; i++)
            {
                char currentDigit = i_str[i];
                if (currentDigit != '0' && currentDigit != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /*Param: string 
        * Return: Boolean value; if the string is a power of 2 returns true, false otherwise.*/
        private static bool IsPowerOf2(string i_str)
        {
            for (int i = 0; i < i_str.Length; i++)
            {
                if (i_str[i] == '1')
                {
                    for (int j = i + 1; j < i_str.Length; j++)
                    {
                        if (i_str[j] == '1')
                        {
                            return false;
                        }
                    }
                } 
            }
            return true;
        }

        /*Param: string 
        * Return: Integer value consisting of the amount of zero's in the input string.*/
        private static int CountZeros(string i_str)
        {
            int amountOfZeros = 0;
            for (int i = 0; i < i_str.Length; i++)
            {
                if (i_str[i] == '0')
                {
                    amountOfZeros++;
                }
            }
            return amountOfZeros;
        }

        /*Param: string 
        * Return: Boolean value; if the string is strictly increasing returns true, false otherwise.*/
        private static bool StrictlyIncreasing(int i_int)
        {
            int currentDigit = 0;
            int prevDigit = 10;
            while (i_int > 0)
            {
                currentDigit = i_int % 10;
                if (currentDigit <= prevDigit)
                {
                    prevDigit = currentDigit;
                    i_int = i_int / 10;
                }
                else
                {
                    return false; 
                }
            }
            return true;
        }

        /*Enum declaration in order to convert decimal's to word representation*/
        private enum NumberConverter
        {
            none,
            one,
            two,
            three,
            four,
        }
    }
}

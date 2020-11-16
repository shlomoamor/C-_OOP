using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_EX01_02
{
    public class Program
    {
        static void Main()
        {
            BuildSandClock(3,0);
            System.Console.Read();
        }

        /* Param: Integer value for height of sand clock and Integer value for recurssion purposes.
         * Return: No return, this method builds a sand clock and prints to the screen*/
        public static void BuildSandClock(int i_height, int count)
        {
            if (i_height == 1)
            {
                for (int i = 0; i < count; i++)
                {
                    System.Console.Write(' ');

                }
                System.Console.WriteLine('*');
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    System.Console.Write(' ');

                }
                for (int i = 0; i < (i_height * 2) - 1; i++)
                {
                    System.Console.Write('*');

                }
                System.Console.Write("\n");
                BuildSandClock(i_height - 1, count+1);
                for (int i = 0; i < count; i++)
                {
                    System.Console.Write(' ');

                }
                for (int i = 0; i < (i_height * 2) - 1; i++)
                {
                    System.Console.Write('*');

                }
                System.Console.WriteLine(' ');
            }
        }
    }
}

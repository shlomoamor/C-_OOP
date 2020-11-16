using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_EX01_03
{
    class Program
    {
        static void Main()
        {
            // getting user input
            System.Console.WriteLine("Please enter sand clock height: ");
            string sandClockHeightStr = "";
            int sandClockHeight = 0;
            while (true)
            {
                sandClockHeightStr = System.Console.ReadLine();
                if ((int.TryParse(sandClockHeightStr, out sandClockHeight) && sandClockHeight > 0))
                {

                    B19_EX01_02.Program.BuildSandClock(sandClockHeight, 0);
                    break;
                }
                else
                {
                    // invalid input
                    System.Console.WriteLine("Please enter a positive integer greater than zero.");
                }
            }


            System.Console.Read();
        }
    }
}

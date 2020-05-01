using System;
using System.Collections.Generic;
using System.Text;

namespace Parallel
{
    public class HappyNumberService
    {
        public bool Calculate(int number, int charNum)
        {
            var charNumHalf = charNum / 2;
            var kind = Math.Pow(10, charNumHalf);
            var firstHalf = number % kind;
            var secondHalf = (number - firstHalf) / kind;
            return firstHalf == secondHalf;
        }

        public int CheckDiapazon(int start, int finish, int charNum)
        {
            var happyNumbersNum = 0;

            for (var i = start; i < finish; i++)
            {
                var isHappy = Calculate(i, charNum);
                if (isHappy)
                {
                    happyNumbersNum++;
                    Console.WriteLine("Happy number: " + i.ToString());
                }
            }

            return happyNumbersNum;
        }
    }
}

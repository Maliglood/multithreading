using System;
using System.Threading;

namespace HappyNumber
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

        public bool CheckNumber(int number, int charNum)
        {
            var isHappy = Calculate(number, charNum);
            if (isHappy)
            {
                Console.WriteLine("Happy number: " + number.ToString());
                return true;
            }

            return false;
        }

        public int FindInDiapazon(int start, int finish, int goal, int charNum, CancellationTokenSource cancelTokenSource, CancellationToken token)
        {
            for (var i = start; i < finish; i++)
            {
                if (!token.IsCancellationRequested)
                {
                    var isHappy = Calculate(i, charNum);
                    if (i == goal)
                    {
                        //cancelTokenSource.Cancel();
                        return i;
                    }
                } else
                {
                    break;
                }
            }

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HappyNumber;

namespace Prallel2
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            // ParallelFunc();
            ParallelFunc2();
            var finishTime = DateTime.Now;
            var time = (finishTime - startTime).TotalMilliseconds;
            Console.WriteLine("Time: " + time.ToString() + " ms");
            Console.ReadKey();
        }

        static void ParallelFunc()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var happyNumbersNum = 0;
            object happyNumbersNum2 = 0;

            Parallel.Invoke(
                () => {
                    var num = happyNumberService.CheckDiapazon(1, 10000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(10000001, 20000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(20000001, 30000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(30000001, 40000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(40000001, 50000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(50000001, 60000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(60000001, 70000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(70000001, 80000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(80000001, 90000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                },
                () => {
                    var num = happyNumberService.CheckDiapazon(90000001, 100000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }
            );

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }

        static void ParallelFunc2()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var happyNumbersNum = 0;
            object happyNumbersNum2 = 0;

            Parallel.For(1, 100000000, (int number) =>
            {
                if (happyNumberService.CheckNumber(number, charNum))
                {
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + 1;
                    }
                }
            });

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }
    }
}

using System;
using System.Threading.Tasks;

namespace Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            // UsualFunc();
            // UsualFunc2();
            ParallelFunc();
            var finishTime = DateTime.Now;
            var time = (finishTime - startTime).TotalMilliseconds;
            Console.WriteLine("Time: " + time.ToString() + " ms");
        }

        static void UsualFunc()
        {
            var happyNumberService = new HappyNumberService();
            var happyNumbersNum = 0;

            for (var i = 1; i < 100000000; i++)
            {
                var isHappy = happyNumberService.Calculate(i, 8);
                if (isHappy)
                {
                    happyNumbersNum++;
                    Console.WriteLine("Happy number: " + i.ToString());
                }
            }

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }

        static void UsualFunc2()
        {
            var happyNumberService = new HappyNumberService();
            var happyNumbersNum = happyNumberService.CheckDiapazon(1, 100000000, 8);

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }

        static void ParallelFunc()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var happyNumbersNum = 0;
            object happyNumbersNum2 = 0;

            Task[] tasks = new Task[10]
            {
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(1, 10000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(10000001, 20000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(20000001, 30000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(30000001, 40000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(40000001, 50000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(50000001, 60000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(60000001, 70000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(70000001, 80000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(80000001, 90000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                }),
                new Task(() => {
                    var num = happyNumberService.CheckDiapazon(90000001, 100000000, charNum);
                    lock (happyNumbersNum2)
                    {
                        happyNumbersNum = happyNumbersNum + num;
                    }
                })
            };

            foreach (var t in tasks)
                t.Start();

            Task.WaitAll(tasks);

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HappyNumber;

namespace Prallel2
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            // TasksFunc();
            // ParallelFuncInvoke();
            // ParallelFuncFor();
            // TasksFindFunc();
            // ParallelFindFunc();
            ParallelFindFuncPrallelOptions();
            var finishTime = DateTime.Now;
            var time = (finishTime - startTime).TotalMilliseconds;
            Console.WriteLine("Time: " + time.ToString() + " ms");
            Console.ReadKey();
        }

        static void TasksFunc()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;

            Task<int>[] tasks = new Task<int>[10]
            {
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(1, 10000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(10000001, 20000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(20000001, 30000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(30000001, 40000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(40000001, 50000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(50000001, 60000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(60000001, 70000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(70000001, 80000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(80000001, 90000000, charNum);
                    return num;
                }),
                new Task<int>(() => {
                    var num = happyNumberService.CheckDiapazon(90000001, 100000000, charNum);
                    return num;
                })
            };

            foreach (var task in tasks)
                task.Start();

            Task.WaitAll(tasks);
            var happyNumbersNum = 0;

            foreach (var task in tasks)
                happyNumbersNum = happyNumbersNum + task.Result;

            Console.WriteLine("Total: " + happyNumbersNum.ToString());
        }

        static void ParallelFuncInvoke()
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

        static void ParallelFuncFor()
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

        static void TasksFindFunc()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var random = new Random();
            var goal = random.Next(100000000);
            Console.WriteLine("Generated number: " + goal.ToString());

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task[] tasks = new Task[10]
            {
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(1, 10000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(10000001, 20000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(20000001, 30000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(30000001, 40000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(40000001, 50000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(50000001, 60000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(60000001, 70000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(70000001, 80000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(80000001, 90000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                }),
                new Task(() => {
                    var res = happyNumberService.FindInDiapazon(90000001, 100000000, goal, charNum,cancelTokenSource, token);
                    if (res > 0)
                    {
                        Console.WriteLine("Found number: " + res.ToString());
                    }
                })
            };

            foreach (var task in tasks)
                task.Start();

            Task.WaitAll(tasks);
            cancelTokenSource.Dispose();
        }

        static void ParallelFindFunc()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var random = new Random();
            var goal = random.Next(100000000);
            // var goal = 99999999; // random.Next(100000000);
            Console.WriteLine("Generated number: " + goal.ToString());

            var result = Parallel.For(1, 100000000, (int number, ParallelLoopState pls) =>
            {
                var isHappy = happyNumberService.Calculate(number, charNum);
                if (number == goal)
                {
                    pls.Break();
                    Console.WriteLine("Found number: " + number.ToString());
                }
            });

            // Console.WriteLine("Break's index: " + result.LowestBreakIteration.ToString());
        }

        static void ParallelFindFuncPrallelOptions()
        {
            var happyNumberService = new HappyNumberService();
            var charNum = 8;
            var random = new Random();
            var goal = random.Next(100000000);
            // var goal = 99999999; // random.Next(100000000);
            Console.WriteLine("Generated number: " + goal.ToString());

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            try
            {
                var result = Parallel.For(1, 100000000, new ParallelOptions { CancellationToken = token }, (int number) =>
                {
                    var isHappy = happyNumberService.Calculate(number, charNum);
                    if (number == goal)
                    {
                        cancelTokenSource.Cancel();
                        Console.WriteLine("Found number: " + number.ToString());
                    }
                });
            }
            catch(OperationCanceledException ex)
            {
                // Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            // Console.WriteLine("Break's index: " + result.LowestBreakIteration.ToString());
        }
    }
}
using System;
using System.Threading.Tasks;

namespace asynchronous_1
{
    class Program
    {
        private static long LongTask()
        {
            long i = 0;
            while (i < 10000000000)
            {
                i++;
            }
            return i;
        }

        public static void Example1()
        {
            Console.WriteLine("Start of long task");
            long i = LongTask();
            Console.WriteLine("End of long task, result: {0}", i);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Synchronous execution =======================");
            Example1();
            Console.WriteLine("Program continuation after example 1");
            Console.WriteLine();


            Console.WriteLine("Asynchronous execution =======================");
            Example2();
            Console.WriteLine("Program continuation after example 2");

            Console.ReadLine();
        }        

        async public static void Example2()
        {
            Console.WriteLine("Start of long task");
            //long i = await LongTaskAsyn();
            long i = await Task.Run(LongTask);
            Console.WriteLine("End of long task, result: {0}", i);
        }                

        private static Task<long> LongTaskAsyn()
        {
            return Task.Run(() => LongTask());
        }

    }

}

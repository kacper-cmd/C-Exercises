using System;

namespace statements_2
{
    class Program
    {
        static void Main(string[] args)
        {            
            const short N = 100;
            const short M = 999;
            Console.WriteLine("Prime numbers from <{0}, {1}>: ", N, M);

            var number = N;
            while(number < M)
            {
                var isPrime = true;
                for (int i = 2; i < Math.Sqrt(number); i++)
                    if (number % i == 0) { isPrime = false; break; }

                if (isPrime) 
                    Console.Write("{0}, ", number);
                number++;
            }

            Console.ReadLine();
        }
    }
}

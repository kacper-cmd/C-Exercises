using System;

namespace exercise_I_9
{
    class Program
    {
        static void Main(string[] args)
        {
            // preparing an input
            Console.Write("Enter N number: ");            
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nUsage of while:");
            { // usage of while

                // needed variables
                int i=1, sum=0;

                // calculations
                while (sum + i <= n)
                {
                    sum += i;
                    Console.Write(i==1?$"{i}":$" + {i}");
                    i++;
                }
                Console.WriteLine();

                // preparing output
                Console.WriteLine($"Count of numbers: {i-1}");
                Console.WriteLine($"Sum of numbers: {sum}");
            }

            Console.WriteLine("\nUsage of do while:");
            {
                int sum = 0, i = 1;
                do
                {
                    if (sum + i > n) break;
                    sum = sum + i;
                    //Console.Write(i == 1 ? $"{i}" : $" + {i}");
                    i++;
                }
                while (true);

                Console.WriteLine("Numbers count is: {0}", i - 1);
                Console.WriteLine("Sum of numbers is: {0}", sum);
            }

            Console.WriteLine("\nUsage of for:");
            { // usage of for
                int i = 1, sum = 1;
                for (; sum <= n; i++, sum += i) ;
                
                //Console.WriteLine();

                // preparing output
                Console.WriteLine($"Count of numbers: {i - 1}");
                Console.WriteLine($"Sum of numbers: {sum - i}");
            }
            
        }
    }
}

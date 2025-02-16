using System;

namespace delegates_0b
{
    // 1. delegate declaration
    delegate void PrintingFunction(string s);

    class Program
    {
        static void Main(string[] args)
        {
            /*
            // 3. creating of the delegate object with passing a delegated function,
            // it means assign a "value" to the delegate
            PrintingFunction f = new PrintingFunction(PrintString1);
            // or simpler
            //PrintingFunction f = PrintString1;

            // 4. invoking (calling) the delegate (in fact delegated function)
            f("Programm in C#");

            // assignment other function to the delegate object
            f = PrintString2;
            f("Programm in C#");

            f = PrintString3;
            f("Programm in C#");
            */
            
            // using multicast delegates we can execute several functions by only one invocation
            PrintingFunction f = PrintString1;
            f += PrintString2;
            f += PrintString3;

            // invocation of multicast delegate
            f("Programm in C#");

            Console.ReadLine();
        }

        // 2. methods - candidates for delegate value - have a signature matched with PrintingFunction delegate type
        static void PrintString1(string text)
        {
            Console.WriteLine("***********************\n{0}\n***********************\n", text);
        }

        static void PrintString2(string text)
        {
            Console.WriteLine("_______________________\n{0}\n_______________________\n", text);
        }

        static void PrintString3(string text)
        {
            Console.WriteLine("=======================\n{0}\n=======================\n", text);
        }
    }
}

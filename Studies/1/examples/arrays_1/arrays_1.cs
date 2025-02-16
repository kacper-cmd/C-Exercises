using System;

namespace arrays_1
{
    // creating and proccessing arrays, loops

    class Test
    {
        static void Main(string[] args)
        {
            ///*
            int[] tab1;
            tab1 = new int[10];

            // initialization
            tab1 = new int[] { 11, 111, 222, 333, 444, 555, 666, 777, 888, 999 };
            //*/

            // in one line with declaration
            //int[] tab1 = { 11, 111, 222, 333, 444, 555, 666, 777, 888, 999 };

            // fills of random integers from <0, 1000> interval 
            Random generator = new Random();
            for (int i = 0; i < 10; i++) tab1[i] = generator.Next(1000);

            // prints all content of an array
            foreach(int element in tab1) Console.Write("{0,5}",element);
            Console.WriteLine();

            // prints only odd numbers from the array
            int j=0;
            while(j < 10) {
                // little strange, but shows usage of continue keyword
                /*
                    if(tab1[j++]%2==0) continue;
                    Console.Write("{0,5}",tab1[j-1]);
                */ 

                if (tab1[j] % 2 != 0) Console.Write("{0,5}", tab1[j]);
                j++;
            }
            Console.WriteLine();

            // nested loop, prints only primary numbers from an array
            j = 0;
            do {
                int i = 2;
                for (; i < tab1[j] / 2; i++) if (tab1[j] % i == 0) break;
                if (i == tab1[j] / 2) Console.Write("{0,5}", tab1[j]);
                j++;
            } while(j<10);

            Console.ReadLine();
        }
    }
}

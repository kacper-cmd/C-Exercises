using System;
using static System.Console;    // to use static members of Console class without a name of class
using static classes_1_4.Generator;

using classes_1_3; // in order to use public Person class from classes_1_3 namespace

namespace classes_1_4
{
    // static class, provides reading from keyboard data of various types
    public static class MyReader
    {
        public static string ReadString() { return Console.ReadLine(); }
        public static int ReadInt() { return int.Parse(ReadLine()); } // ReadLine(), not Console.ReadLine() thanks to using static
        public static double ReadDouble() { return double.Parse(ReadLine()); }
    }

    // static class, provides randomly generators
    public static class Generator 
    {
        private static Random r;
        static Generator() { r = new Random(); }
        public static int[] selectIndexes(int count, object[] store) {
            int[] result = new int[count];            
            for (int i = 0; i < count; i++)
                result[i] = r.Next(store.Length);
            return result;
        }
    }
    
    class classes_1_4
    {
        static void Main(string[] args)
        {
            object[] input = new object[] {11,22,33,44,55,66,77,88,99};
            int[] selected = selectIndexes(3, input); // selectIndexes(), not Generator.selectIndexes() thanks to using static
            foreach (int element in selected)
                Console.WriteLine(input[element]);
            Console.ReadLine();            

            // usage of a class from outside of this project:
            // 1) in project add reference to assembly containing required class
            // 2) add using directive to appriopriate namespace
            // 3) used class must be public
            //*
            Person[] input2 = new Person[] { 
                new Person("John", "Rambo"), 
                new Person("James", "Bond"), 
                new Person("Lara", "Croft") 
            };
            int[] selected2 = Generator.selectIndexes(2, input2);
            foreach (int element in selected2)
                input2[element].Show();
            Console.ReadLine();
            //*/

	    // Test of MyReader class
            //*
            WriteLine("\n=== Test of using a static class ===\n");

            Write("Enter first number: ");
            int x = MyReader.ReadInt();
            Write("Enter second number: ");
            int y = MyReader.ReadInt();
            WriteLine("Sum of given numbers is: {0}",x+y);
            WriteLine();
            //*/
        }
    }
}

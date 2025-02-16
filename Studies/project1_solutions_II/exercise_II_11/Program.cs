/*
The class should have a static field of Random type and a static constructor, 
which creates an object being a value of the field.
Moreover, in RandomUtility class define methods:
a.	to random generating a number from giving range 
(for types int and double): randomInt(a, b), randomDouble(a, b)
b.	to random generating a string consist of  n whichever chars: randomString(n)
c.	to random selecting n elements from given array (with or without repetitions): randomFromArray(n, array, rep)
Test these methods in the Test class.
*/

using System;

namespace exercise_II_11
{
    static class RandomUtility
    {
        static Random generator;
        static RandomUtility() { generator = new Random(); }

        public static int RandomInt(int a, int b)
        {
            return a + generator.Next(1 + b - a);
        }
        
        public static double RandomDouble(double a, double b)
        {            
            return a + generator.NextDouble() * Math.Abs(b - a);
        }
        public static string RandomString(int n)
        {
            // A. preparing charSet by hand
            const string charSet =
                "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // B. preparing an array with indices in ASCII codes for letters and digits only
            // codes taken as heksadecimals
            int[] charSetIndices = new int[62];
            int k = 0;
            for (int j = 0x30; j <= 0x39; k++, j++) charSetIndices[k] = j; // digits
            for (int j = 0x41; j <= 0x5A; k++, j++) charSetIndices[k] = j; // upper letters
            for (int j = 0x61; j <= 0x7A; k++, j++) charSetIndices[k] = j; // lower letters

            // checking constructed array
            //Console.WriteLine(k);
            //for (int i = 0; i < k; i++) Console.WriteLine((char)charSetIndices[i]);

            char[] chars = new char[n];
            for (int i = 0; i < n; i++)
            {
                // A.
                //chars[i] = charSet[generator.Next(charSet.Length)];

                // B.
                chars[i] = (char)charSetIndices[generator.Next(charSetIndices.Length)];

                // C. whole ASCII codes set: 0x21 - 0x7E
                //chars[i] = (char) RandomInt(0x21, 0x7E); 
            }
            return new string(chars);
        }

        public static object[] randomFromArray(int n, object[] array, bool rep)
        {            
            object[] result = new object[n];
            if (rep) {
                for (int i = 0; i < n; i++)
                {
                    result[i] = array[generator.Next(0, n)];
                }
            }
            else
            {
                if (n > array.Length) return null;
                int?[] indices = new int?[array.Length];
                for (int i = 0; i < indices.Length; i++) indices[i] = i;
                for (int i = 0; i < n; i++)
                {
                    int selIdx;
                    do { selIdx = generator.Next(0, n); } while (indices[selIdx] == null);
                    result[i] = array[selIdx];
                    indices[selIdx] = null;
                }
            }
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 10, c = 15;
            Console.WriteLine($"Random integer from {a} to {b}: " +
                              $"{RandomUtility.RandomInt(a, b)}");
            Console.WriteLine($"Random double from {a} to {b}: " +
                              $"{RandomUtility.RandomDouble(a, b)}");            
            Console.WriteLine($"Random string with {c} characters: " +
                              $"{RandomUtility.RandomString(c)}");

            Console.WriteLine($"Random values from an array: ");
            object[] selectedObjects = RandomUtility.randomFromArray(5, new object[] { 11, 22, 33, 44, 55, 66 }, true);
            foreach (object item in selectedObjects) Console.Write($"{item,5}");
            Console.WriteLine();

            Console.WriteLine($"Random values from an array: ");
            object[] selectedUnique = RandomUtility.randomFromArray(3, new object[] { 11, 22, 33, 44, 55, 66 }, false);
            foreach (object item in selectedUnique) Console.Write($"{item,5}");
        }
    }
}

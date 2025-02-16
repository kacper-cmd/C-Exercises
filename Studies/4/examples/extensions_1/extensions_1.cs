using System;

namespace extensions_1
{
    class Extensions_1
    {
        static void Main(string[] args)
        {
         // example 1: extension of String class
         // my own methods work as methods of String class
            string text = ".....Hello. Krzysiek. ...";

            Console.WriteLine(text.removeDots());
            Console.WriteLine(text.replaceDots("STOP"));
            Console.WriteLine(text.replace1(s => s.Replace(".","/")));
            Console.WriteLine(text.replace2(s => s.Replace(".", "-")));

         // example 2: extension of Object class
            (12.5).showType();

            Console.ReadLine();
        }
    }

    static class Suplement
    {
        // 1
        public static string removeDots(this string s) { return s.Replace(".", ""); }
        // 2
        public static string replaceDots(this string s, string substitute) { 
            return s.Replace(".", substitute); 
        }
        // 3
        public delegate string stringModification(string s);
        public static string replace1(this string s, stringModification howToChange)
        {
            return howToChange(s);
        }
        // 4, usage of Func<T1, T2> delegate
        public static string replace2(this string s, Func<string, string> howToChange)
        {
            return howToChange(s);
        }

        // 5, here I extend functionality of Object class (any object) to print name of its type
        public static void showType(this object obj) 
        {
            Console.WriteLine(obj.GetType().FullName);
        }

    }
}

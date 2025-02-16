using System;
using System.IO;

namespace exercise_XV_1
{
    class exercise_XV_1
    {
        static void Main(string[] args)
        {
          // test of XV.1 A i C         
            Console.WriteLine("World Health Organization".Acronym());

            Console.WriteLine("World Health Organization".IsPalindrome());
            Console.WriteLine("Zakład Ubezpieczeń Zdrowotnych".Acronym().IsPalindrome());
            Console.WriteLine("level".IsPalindrome());
            Console.WriteLine("kkkk".IsPalindrome());

        // test of XV.1 B
            string text = ".....Witaj. Krzysiek. ...";
            text.ToFile("notes.txt");

            Console.ReadLine();            
        }
    }

    static class Suplement
    {                       
        public static string Acronym(this string s)
        {
            string acronym = "";
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                acronym += word.Substring(0, 1).ToUpper();
            }
            return acronym;
        }

        public static bool IsPalindrome(this string s)
        {            
            for (int i = 0, j = s.Length - 1; i < s.Length; i++, j--)
            {
                if (s[i] != s[j]) return false;                
            }
            return true;
        }

        public static void ToFile(this string s, string fileName)
        {
            StreamWriter file = new StreamWriter(fileName, true);
            file.WriteLine(s);
            file.Close();
        }

    }
}

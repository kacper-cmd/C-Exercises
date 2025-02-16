using System;

namespace exercise_II_A2
{
    class Program
    {
        static void Main()
        {
            // needed data structure
            const byte PHRASES_COUNT = 3;
            string[] phrases = new string[PHRASES_COUNT];

            // preparing input
            for (int i = 0; i < PHRASES_COUNT; i++)
            {
                Console.Write($"Enter phrase number {i+1}: ");
                phrases[i] = Console.ReadLine();
            }

            // processing
            string resultText = null;
            foreach(string phrase in phrases)
            {
                string sentence = phrase[0].ToString().ToUpper() + phrase.Substring(1) + ". ";
                resultText += sentence;
            }

            // preparing output
            Console.WriteLine($"Final text:\n {resultText}");

        }
    }
}

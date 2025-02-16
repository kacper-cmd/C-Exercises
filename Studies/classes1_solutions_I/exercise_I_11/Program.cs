using System;

namespace exercise_I_11
{
    class Program
    {
        static void Main(string[] args)
        {            
                int handValue = 0;
                string str;
              
              // needed to 11b
                Random random = new Random();
                string[] cardNames = { "ace", "ten", "king", "queen", "jack", "nine" };
                int idx;

                for (int i = 0; i < 5; i++)
                {
                    /* 11.a
                    Console.Write("Enter a card name: ");
                    str = Console.ReadLine();
                    */

                    // 11.b                    
                    idx = random.Next(cardNames.Length);
                    str = cardNames[idx];
                    Console.WriteLine($"Card {i+1}: {str}");

                    // both
                    switch (str)
                    {
                        case "ace":
                            handValue += 11;
                        break;
                        case "ten":
                            handValue += 10;
                        break;
                        case "king":
                            handValue += 4;
                        break;
                        case "queen":
                            handValue += 3;
                        break;
                        case "jack":
                            handValue += 2;
                        break;
                        case "nine":                            
                        break;

                        default:
                            Console.WriteLine("Wrong card name!"); i--;
                        break;
                    }

                }
                Console.WriteLine("\nValue of your hand is: {0}", handValue);
        }
    }
}

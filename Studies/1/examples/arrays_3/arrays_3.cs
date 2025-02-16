using System;
using System.Text;

namespace arrays_3
{    
    class Test
    {
        static void Main(string[] args)
        {           
            // declares and initializes an array of strings
            string[] tomSays = {"Welcome", "Good morning", "Hi", "It's nice to see you", "Hello"};            
            
            // draws and shows one of welcomes
            Random generator = new Random();
            int selectedIdx = generator.Next(tomSays.Length);
            Console.WriteLine("Tom: {0}",tomSays[selectedIdx]);            
           
            // Jerry copies Tom's list of welcomes, draws one of them and answers
            string[] jerrySays = (string[])tomSays.Clone();

            // Clone() method creates a "shallow" copy of an array
            // (that is if elements of the array are references only these references are copied)            

            selectedIdx = generator.Next(jerrySays.Length);
            Console.WriteLine("Jerry: {0}", jerrySays[selectedIdx]);
            
            // draws a product (one row of 2-dimensional array)
            string[,] products = { { "a wardrobe", "2000" }, { "a table", "1500" }, { "a chair", "300" } };
            int selectedProductIdx = generator.Next(products.GetLength(0));
            Console.WriteLine("Tom: I want to buy {0}", products[selectedProductIdx, 0]);
            Console.WriteLine("Romek: OK. You pay {0:c}", 
                                int.Parse(products[selectedProductIdx, 1]));

            Console.ReadLine();            
        }
    }
}

using System;

namespace ex_II_4
{
    class Program
    {
        static void Main(string[] args)
        {
         // variables I need
            Random generator = new Random();  // prepares object to draw
            int number;                 // one of numbers (using in loop)
            string numberAsString;        // number as string

            const byte NUMBERS_COUNT = 5;
            byte[][] digits = new byte[NUMBERS_COUNT][]; // prepare resulting array of digits
         
            Console.Write("Randomly generated numbers are: ");
            for (int i = 0; i < NUMBERS_COUNT; i++)
            {
                number = generator.Next(1001);            // drawing
                Console.Write("{0,5}", number); // display the number on the console

                numberAsString = number.ToString();   // convert to string
                digits[i] = new byte[numberAsString.Length];   // prepares i-th row of jagged array (for store digits of i-th number) 
                for (int j = 0; j < digits[i].Length; j++)   // loop by every char of string representing the i-th number
                    digits[i][j] = byte.Parse(numberAsString.Substring(j, 1)); // j-th digit of i-th number is convert to byte and store in array                
            }
            Console.WriteLine();

           // loop displaying resulting array 
            Console.WriteLine("Resulting array is: ");
            for (int i = 0; i < NUMBERS_COUNT; i++)
            {
                for (int j = 0; j < digits[i].Length; j++)
                    Console.Write("{0,2}", digits[i][j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

/* 
 Outline of another (mathematical) solution:
 For each generated number do steps 1 - 3.
 1. Calculate how many digits has the number (in loop compare number to power of 10, from 1 until the power exceeded giving number)
    For example for number 1200 we have: 10^1 <= 1200; 10^2 <= 1200; 10^3 <= 1200; 10^4 > 1200 so our number has 4 digits.
 2. Prepare row of output array (using new keyword, like in jagged arrays)
 3. In a loop:
    a. calculate a remainder of division of given number by 10 (result will be first digit of number from right)
    b. store the digit to array
    c. divide the number by 10 and back to step 3a.
 4. Finally display resulting array.
 
 I encourage to try :)
*/



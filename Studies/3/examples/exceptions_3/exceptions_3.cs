using System;

namespace exceptions_3
{
    class exceptions_3
    {
        static void Main(string[] args)
        {

            decimal x = 0;
            int y = 0;

            while (true)
            { 
                
                try
                {
                    Console.Write("Enter gross price: ");
                    x = Reader.readDecimal();

                    // validation of gross price
                    if (x < 0) throw new ArithmeticException();

                    Console.Write("Enter VAT rate: ");
                    y = Reader.readInt();

                    // validation of vat rate
                    if (y < 0) throw new ArithmeticException("VAT rate can't be negative");
                  // or
                    if (y > 100 || y < 0) throw new InvalidVAT();
                  
                  // if the control comes here, it means that input data are valid
                  // so time to leave the loop

                    break;                              
              
                }                        
                catch (ArithmeticException e)
                {
                  Console.WriteLine(e.Message);
                  //return;
                }
                catch (InvalidVAT e)
                {
                  Console.WriteLine(e.Message);
                  //return;
                }            
                catch (Exception e)
                {
                    Console.WriteLine("Some failure. Contact with the program producer.\n"
                                   + e.Message);
                    //return;
                }            
                 
                finally
                {
                    Console.WriteLine("Finally section code.");
                    Console.ReadLine();
                }

                Console.Clear();

        } // end of the loop

            Console.WriteLine("The program continuation.");
            Console.WriteLine("Net price: {0:c}", x / (1 + (decimal)y / 100));

            Console.ReadLine();

        }
    }

    // a definition of an exception class
    class InvalidVAT : Exception
    {
        public InvalidVAT()
            : base("Invalid value for a VAT rate")
        { }        
    }

}
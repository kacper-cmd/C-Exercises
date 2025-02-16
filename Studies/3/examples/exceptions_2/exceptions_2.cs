using System;

// exceptions throwing
// custom exceptions classes

namespace exceptions_2
{
    class exceptions_2
    {
        static void Main(string[] args)
        {

          try
            {                
                Console.Write("Enter gross price: ");
                decimal x = Reader.readDecimal();
                Console.Write("Enter VAT rate: ");
                int y = Reader.readInt();

              // explicitly throwing of ArithmeticException
                if (x < 0) throw new ArithmeticException();

              // throwing an built-in exception type with some message
                if (y < 0) throw new ArithmeticException("VAT rate can't be negative");

              // throwing newly created exception
                if (y > 100 || y < 0) throw new InvalidVAT();

                Console.WriteLine("Net price: {0:c}", x / (1 + (decimal)y/100));

            // how to test:
            // put negative gross price
            // put negative vat rate
            // put vat rate over 100
            // put a text instead of a number       

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

            Console.WriteLine("The program continuation.");
            Console.ReadLine();

        }
    }

    // a definition of an exception class
    class InvalidVAT : Exception
    {
        public InvalidVAT()
            : base("Invalid value for a VAT rate")
        {
            //this.Message = "Invalid value for a VAT rate"; // not allowed - it's readonly property
        }

        // write a code, which allows to show an invalid value inside error message
        // hint: define other constructor with a parameter
    }

}
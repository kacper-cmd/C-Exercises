using System;

namespace exceptions_1
{
    class exceptions_1
    {
        static void Main(string[] args)
        {

          // unhandled error causes unexpected termination of a program
          /*
            int x = 0;
            int y = 2 / x;
          */

          
            try 
                // a code in try block is under exceptions mechanism care
                // so if I'm afraid of an exception occurence in some code
                // I place it in try block
            {
                Console.Write("Enter a number x: ");
                byte x = Reader.readByte();
                Console.Write("Enter a number y: ");
                byte y = Reader.readByte();

                int result = x / y;

            // how to test this code:
            // put y=0 (and any x), it will force division by zero exception
            // put x or y greater than 255, it will force overflow of byte type
            // put a non-number value, it will force invalid format exception

            }
            
            // below catches handle various types of exceptions
            // only type of exception
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero. Contact to the nearest mathematician, please.");                
            }
            
            // type and variable if we want to use it
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow, a value is too big to store in a memory.\n"
                                   + e.Message);                
            }
            // Exception class handles any type of exception (unless it has been handled by previous catches)
            // inside the catch we can use an object representing thrown exception
            catch (Exception e)
            {
                Console.WriteLine("Some failure. Contact with the program producer, please.\n{0}\n{1}"
                                   , e.Message, e);
                //return;
            }
            // mogę nie podawać argumentu Exception jak nie zależy mi na jego użyciu
            // This catch handles any type of exception, too. However, we have no access to the exception's object.
            catch
            {
                Console.WriteLine("Something is wrong. Contact with the program producer, please.");
                //return;                
            }
             
            finally // this code executes every time
            {                
                Console.WriteLine("Code from finally section.");
                Console.ReadLine();
            }

            // this code can be not executed, if an exception handler doesn't allow to continue
            Console.WriteLine("The program continuation.");
            Console.ReadLine();

        }
    }
}
using System;

namespace delegates_4
{

    delegate double ToCalculation();

    class delegates_4
    {
        static void Main(string[] args)
        {
            Operations pair1operations = new Operations(5, 4);
            
            // creating delegate's instance and assignment add() method from class Operations to it
            ToCalculation makeOperations = pair1operations.add;
            
            // adding mult() method to 'makeOperations' instance
            makeOperations += pair1operations.mult;
            
            // invocation of delegate - all methods added to makeOperations will be execute
            makeOperations();

            Console.ReadKey();
        }
    }

    class Operations
    {
        double a, b;
        public Operations(double a, double b)
        {
            this.a = a; this.b = b;
        }

        public double add()
        {
            show("+", a + b); return a + b;
        }

        public double mult()
        {
            show("*", a * b); return a * b;
        }

        // below method builds an expression string and writes it out on the console
        private void show(string oper, double result)
        {
            Console.WriteLine("{0} {1} {2} = {3}", a, oper, b, result);
        }

    }
    
}

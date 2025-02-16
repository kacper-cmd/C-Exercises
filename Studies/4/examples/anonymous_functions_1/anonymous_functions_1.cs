using System;

namespace anonymous_functions_1
{
 // delegate types needed to examples below
    delegate int F(int x);
    delegate bool Comparer(float x, float y);
    delegate double GetDouble();

    class Anonymous_functions_1
    {
        static void Main(string[] args)
        {
          // I. a delegate instance and a method assigned to it
            F f1 = new F(inc1);

          // II. an anonymous method
            // F f1 = delegate(int n) { return n+1; };

          // III. lambda expression
            // F f1 = x => x + 1;
          
          // using the instance
            Console.WriteLine(f1(4));
            

        // EXERCISE:
        // use three ways presented above, to comparison of two float numbers and to calculation of square root from 2

            Comparer comp = compare;
            //Comparer comp = delegate(float x, float y) { return x == y; };
            //Comparer comp = (x, y) => x == y;
            Console.WriteLine(comp(1.1f, 1.2f));

            GetDouble sqr2 = squareRootFrom2;
            //GetDouble sqr2 = delegate { return Math.Sqrt(2); };
            //GetDouble sqr2 = () => Math.Sqrt(2);
            Console.WriteLine(sqr2());

            Console.ReadLine();
        }

        // methods for delegates
        static int inc1(int n) { return n + 1; }
        static bool compare(float x, float y) { return x == y; }
        static double squareRootFrom2() { return Math.Sqrt(2); }
    }
}

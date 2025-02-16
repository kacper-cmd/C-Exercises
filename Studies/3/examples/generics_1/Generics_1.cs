using System;

namespace generics_1
{
    // generic class
    class Pair<T1, T2>
    {
        private T1 x;
        private T2 y;

        public Pair(T1 x, T2 y)
        {
            this.x = x;
            this.y = y;
        }

        public void print()
        {
            Console.WriteLine("Pair ({0}, {1})", x, y);
        }

    }


    class Generics_1
    {
        static void Main(string[] args)
        {

            Pair<int, float> pair1 = new Pair<int, float>(5, 7.5f);
            pair1.print();

            Pair<string, string> pair2 = new Pair<string, string>("Tom", "Jerry");
            pair2.print();

            // try to create a pair of persons 

            // using of generic method
            // we don't need specify type parameters, they are assumed based on method's arguments types
            Console.WriteLine("\nMax value is: {0}", maxFrom2(12.56,12.55));

            Console.ReadLine();
        }
        
        // comparison of two "things"
        // a generic method in non-generic class
        static T maxFrom2<T>(T x, T y) where T : IComparable
        {
            if (x.CompareTo(y) < 0) return y; else return x;                 
        }

    }
}

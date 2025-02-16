using System;

namespace vector
{
    class Test
    {
        static void Main(string[] args)
        {           
            double[] dataForVector = new double[] { 1.5, 2.5, 5, 10, 20 };
            Vector v1 = new Vector(5, dataForVector);
            Vector v2 = new Vector(5, new double[] { 1.5, 2.5, 5, 10, 20 });

            // test V.1a
            Vector w = v1 + v2;
            Console.Write("Sum of two vectors: ");
            w.show();

            // test V.1b
            Console.Write("Scaling vector by 2: ");
            (2 * w).show();

            // test V.1c
            Console.WriteLine($"Scalar product is: {v1*v2}");

            Console.ReadLine(); // to stop a console
        }
    }
}

using System;

namespace vector
{
    partial class Vector
    {
        public static Vector operator +(Vector a, Vector b)
        {
            return a.add(b);
        }

        public static Vector operator *(double a, Vector v)
        {
            Vector result = new Vector(v.rank, v.coordinates);
            for (int i = 0; i < result.rank; i++) result.coordinates[i] *= a;
            return result;
        }

        public static double operator *(Vector v, Vector w)
        {
            double result = 0;
            for (int i = 0; i < v.rank; i++)
                result += v.coordinates[i] * w.coordinates[i];
            return result;
        }
    }
}
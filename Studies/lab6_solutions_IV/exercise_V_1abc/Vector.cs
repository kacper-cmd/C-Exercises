using System;

namespace vector
{
    partial class Vector
    {
        private int rank;
        private double[] coordinates;

        public Vector(int n, double[] data)
        {
            rank = n;
            coordinates = new double[rank];
            for (int i = 0; i < rank; i++) coordinates[i] = data[i];
        }

        public void show()
        {
            Console.Write("[");
            for (int i = 0; i < rank - 1; i++)
                Console.Write(coordinates[i] + ";");
            Console.WriteLine("{0}]", coordinates[rank - 1]);
        }

        public double sum()
        {
            double result = 0;
            for (int i = 0; i < rank; i++)
                result += coordinates[i];
            return result;
        }

        public Vector add(Vector secondOne)
        {
            // prepare a data array for resulting vector
            double[] result = new double[rank];
            // loop calculating coordinates of resulting vector
            for (int i = 0; i < rank; i++)
                result[i] = secondOne.coordinates[i] + this.coordinates[i];
            // create object to return as a result
            return new Vector(rank, result);
        }    
    }

}

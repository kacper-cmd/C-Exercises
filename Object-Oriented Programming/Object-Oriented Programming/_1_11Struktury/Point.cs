namespace _1_11Struktury
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public struct Line
    {
        public Point Begginning;
        public Point Ending;

        public Line(Point begginning, Point ending)
        {
            Begginning = begginning;
            Ending = ending;
        }

        public double CalculateLenght()
        {
            var x1 = Begginning.X;
            var y1 = Begginning.Y;
            var x2 = Ending.X;
            var y2 = Ending.Y;

            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

    }

    public struct Triange
    {
        public Line A { get; set; }
        public Line B { get; set; }
        public Line C { get; set; }

        public Triange(Line a, Line b, Line c)
        {
            A = a;
            B = b;
            C = c;
        }

        public bool CanMakeTriangle()
        {
            var aLenght = A.CalculateLenght();
            var bLenght = B.CalculateLenght();
            var cLenght = C.CalculateLenght();

            var lines = new List<double> { aLenght, bLenght, cLenght };
            var largestLine = lines.Max();
            return lines.Sum() - largestLine * 2 > 0;
        }
    }
}

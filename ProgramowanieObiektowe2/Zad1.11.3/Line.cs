public struct Line
{
    public Point Start { get; }
    public Point End { get; }
    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
    
    public double Length
    {
        get
        {
            double x = End.X - Start.X;
            double y = End.Y - Start.Y;
            return Math.Sqrt(x * x + y * y);
            //  |AB| = sqrt( (x2-x1)^2 +(y2-y1)^2 )
        }
    }
}
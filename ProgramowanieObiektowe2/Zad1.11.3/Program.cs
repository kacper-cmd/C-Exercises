class Program
{
    static void Main()
    {
        Point p1 = new Point(0, 0);
        Point p2 = new Point(2, 0);
        Point p3 = new Point(1, 3);

        Line line1 = new Line(p1, p2);
        Line line2 = new Line(p2, p3);
        Line line3 = new Line(p3, p1);

        Triangle triangle = new Triangle(line1, line2, line3);

        Console.WriteLine($"Line 1 length: {line1.Length}");
        Console.WriteLine($"Line 2 length: {line2.Length}");
        Console.WriteLine($"Line 3 length: {line3.Length}");
        Console.WriteLine($"Can build a triangle: {triangle.CanBuildATriangle}");

    }
}

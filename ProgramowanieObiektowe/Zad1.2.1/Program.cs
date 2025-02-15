class Program
{
    static void Main()
    {
        List<Point3D> PointsIn3D = new List<Point3D>
        {
            new Point3D(0, 0, 0),
            new Point3D(0, 0, 1),
            new Point3D(0, 1, 0),
            new Point3D(0, 1, 1),
            new Point3D(1, 0, 0),
            new Point3D(1, 0, 1),
            new Point3D(1, 1, 0),
            new Point3D(1, 1, 1)
        };
        foreach (var point in PointsIn3D)
        {
            Console.WriteLine(point);
        }
    }
}

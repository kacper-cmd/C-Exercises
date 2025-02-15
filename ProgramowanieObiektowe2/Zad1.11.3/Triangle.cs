public struct Triangle
{
    public Line SideA { get; }
    public Line SideB { get; }
    public Line SideC { get; }

    public Triangle(Line sideA, Line sideB, Line sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    /// <summary>
    /// Trójkąt o bokach a, b, c można zbudować jeżeli suma dwóch boków jest większa od sumy trzeciego boku
    /// </summary>
    public bool CanBuildATriangle
    {
        get
        {
            double lengthA = SideA.Length;
            double lengthB = SideB.Length;
            double lengthC = SideC.Length;

            return (lengthA + lengthB > lengthC) &&
                   (lengthA + lengthC > lengthB) &&
                   (lengthB + lengthC > lengthA);
        }
    }
}
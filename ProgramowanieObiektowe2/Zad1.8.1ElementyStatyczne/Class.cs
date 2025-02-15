public class Class
{
    public static int classCounter = 0;
    public Class()
    {
        ++classCounter;
    }
    public static void DisplayClassCounter()
    {
        Console.WriteLine($"Created object of Class -> {classCounter} <-");
    }
}
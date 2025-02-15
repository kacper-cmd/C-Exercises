namespace _1_8ElementyStatyczne
{
    internal class Class1
    {
        private static int Counter = 0;

        public Class1() { Counter++; }
        static public void ShowNumberOfObjects()
        {
            Console.WriteLine(Counter);
        }
    }
}

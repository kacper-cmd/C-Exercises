namespace _1._6Konstruktor
{
    internal class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public static int DogsCount = 0;
        public Dog(string name, int age, string race)
        {
            Name = name;
            Age = age;
            Race = race;
            DogsCount++;
        }
        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
            Race = "Mongrel";
            DogsCount++;
        }

    }
}

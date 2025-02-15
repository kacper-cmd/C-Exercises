namespace ClassLibraryZad1._5._1
{
    public class Animal
    {
        private void AnimalMethod()
        {
            Console.WriteLine(" I' m from Animal class -> private method");
        } 
        public void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }
        protected int Age { private get;  set; }
        public void DisplayAge()
        {
            Console.WriteLine($"I am {Age} years old");
        }
        internal void MethodEX6()
        {
            Console.WriteLine("Method from 6 ex");
        }
    }
}

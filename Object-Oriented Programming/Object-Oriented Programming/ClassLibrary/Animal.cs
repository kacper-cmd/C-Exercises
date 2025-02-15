namespace ClassLibrary
{
    public abstract class Animal
    {
        protected int Age { get; set; }

        public abstract void MakeSound();

        internal void BeDog()
        {
        }

        private void BeAnimal()
        {
        }
    }
}
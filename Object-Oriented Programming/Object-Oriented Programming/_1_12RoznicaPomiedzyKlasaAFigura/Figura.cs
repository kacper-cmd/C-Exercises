namespace _1_12RoznicaPomiedzyKlasaAStruktura
{
    public interface Figura
    {
        void WyswietlWzor();
    }

    public struct Kwadrat : Figura
    {
        public void WyswietlWzor()
        {
            Console.WriteLine("P = a * a");
        }
    }
}
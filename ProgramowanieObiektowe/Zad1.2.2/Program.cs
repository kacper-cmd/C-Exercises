using Zad1._2._2;
class Program
{
    static void Main()
    {
            Pracownik pracownik = new Pracownik("Kacper", "Obrzut", "Programista", 5000m, 26, 10);
            int dniUrlopu = 5;
            Console.WriteLine("Imię: " + pracownik.GetImie());
            Console.WriteLine("Nazwisko: " + pracownik.GetNazwisko());
            Console.WriteLine("Stanowisko: " + pracownik.GetStanowisko());
            Console.WriteLine("Pensja: " + pracownik.GetPensja());
            Console.WriteLine("Dostępny urlop: " + pracownik.GetDostepnyUrlop());
            Console.WriteLine("Wykorzystany urlop: " + pracownik.GetWykorzystanyUrlop());
        
    }
}

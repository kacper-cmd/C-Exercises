using Zad1._6._1;
class Program
{
    static void Main()
    {
        try
        {
            Dog burekDog = new Dog("Burek", 4);
            burekDog.DisplayDetails();
            Dog doraDog = new Dog("Dora", 4, "Sheep-dog");
            doraDog.DisplayDetails();

            Console.WriteLine($"Number of dogs ->: {Dog.GetDogCounter()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error ->: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error ->: {ex.Message}");
        }
    }
}
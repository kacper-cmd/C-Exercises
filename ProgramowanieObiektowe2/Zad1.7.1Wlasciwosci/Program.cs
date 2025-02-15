using Zad1._7._1Wlasciwosci;
class Program
{
    static void Main()
    {
        Person person = new Person("Kacper", "Obrzut");

        person.Name = "Michal";
        person.Surname = "Michalski";
        try
        {
            person.SetAge(23);
            person.SetGender("male");
            //zad 2
            person.Age = 25;
            person.Gender = "female";
            //person.Age = 121; 
            //person.Gender = "i dont know";
            Console.WriteLine($"Name: {person.Name} {person.Surname}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Gender: {person.Gender}");
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
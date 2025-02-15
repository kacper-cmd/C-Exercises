namespace Zad1._6._1;
public class Dog
{
    #region Propeties
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Breed { get; private set; }//rasa

    private static int dogCounter = 0;
    #endregion

    #region Constructor
    public Dog(string name, int age, string breed)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name not provided.", nameof(name));
        }
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be negative.", nameof(age));
        }
        if (string.IsNullOrWhiteSpace(breed))
        {
            throw new ArgumentException("Breed cannot be null or empty.", nameof(breed));
        }
        Name = name;
        Age = age;
        Breed = breed;
        ++dogCounter;
    }
    public Dog(string name, int age) : this(name, age, "Mongrel")
    {
    }

    #endregion

    #region Methods
    public void DisplayDetails()
    {
        Console.WriteLine($"Dog's -> Name: {Name}, Age: {Age}, Breed: {Breed}");
    }
    public static int GetDogCounter()
    {
        return dogCounter;
    }
    #endregion
}

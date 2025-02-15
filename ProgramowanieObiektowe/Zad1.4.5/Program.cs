public class Program
{
    #region zad7
    static Action<List<User>, string> displayUsersByNameStartingWithGivenLetter = (list, startLetter) =>
    {
        var filtersUser = list.Where(user => user.Name.StartsWith(startLetter, StringComparison.OrdinalIgnoreCase)).ToList();
        if (filtersUser.Count > 0)
        {
            Console.WriteLine($"User with Name start's with {startLetter}");
            filtersUser.ForEach(user =>
                    Console.WriteLine($"Name: {user.Name}, Surname {user.Surname}, Age: {user.Age}" +
                    $"Address {user.Address}, Gender: {user.Gender}, Age: {user.Age}, Email: {user.Email}"));
        }
        else
        {
            Console.WriteLine($"No users ! with the  name begins with {startLetter} letter");
        }
    };
    #endregion

    public static void Main()
    {
        #region zad6
        List<User> users = new List<User>
        {
            new User { Gender = Gender.Male, Name = "Kacper", Surname = "Obrzut", Address ="33-300 NS", Age = 23,Email = "kacper@gmail.com" },
            new User { Gender = Gender.Male, Name = "Marek", Surname = "Markowski", Address ="33-300 NS", Age = 23,Email = "marek@gmail.com" },
            new User { Gender = Gender.Female, Name = "Anna", Surname = "Szewczyk", Address ="33-300 NS", Age = 53,Email = "anna@gmail.com" },
            new User { Gender = Gender.Female, Name = "Alicja", Surname = "Szewczyk", Address ="33-300 NS", Age = 23,Email = "alicja@gmail.com" },
            new User { Gender = Gender.Male, Name = "Wojtek", Surname = "Wojtowski", Address ="33-300 NS", Age = 23,Email = "wojtek@gmail.com" },
            new User { Gender = Gender.Female, Name = "Bloody", Surname = "Marry", Address ="Hell", Age = 123,Email = "marry@gmail.com" },
            new User { Gender = Gender.Male, Name = "Jozef", Surname = "Jozefowicz", Address ="Krakow", Age = 33,Email = "jozek@gmail.com" },
            new User { Gender = Gender.Male, Name = "Richard", Surname = "Backend", Address ="LA, CA", Age = 33,Email = "richard@gmail.com" },
            new User { Gender = Gender.Male, Name = "Pawel", Surname = "Pawlowski", Address ="Chicago", Age = 53,Email = "pawlo@gmail.com" },
            new User { Gender = Gender.Female, Name = "Paulina", Surname = "Paulinkowska", Address ="Gdansk", Age = 63,Email = "paula@gmail.com" },
        };

        Console.WriteLine("Users:");
        int count = 1;
        foreach (var user in users)
        {
            Console.WriteLine($"{count++}. Name: {user.Name}, Surname {user.Surname}, " +
                $"Address {user.Address}, Gender: {user.Gender}, Age: {user.Age}, Email: {user.Email}");
        }
        #endregion
   
        #region zad7

        Console.WriteLine("Zad 7");
        string startNameLetter = "A";
        ///https://www.tutorialsteacher.com/csharp/csharp-action-delegate
        displayUsersByNameStartingWithGivenLetter(users, startNameLetter);

        #endregion

        #region zad8

        Console.WriteLine("Zad 8");
        User user1 = new User();
        user1.AddUsers(users, startNameLetter);

        #endregion

        #region zad9
        
        var uniqueNames = users.Select(u => u.Name).Distinct().ToList();
        var usersWith10YearsAdded = users.Select(u => u.Age + 10 ).ToList();

        var femaleCount = users.Count(u => u.Gender == Gender.Female);
        var maleCount = users.Count(u => u.Gender == Gender.Male);

        var sortByAge = users.OrderBy(u => u.Age).ToList();
        var sortByName = users.OrderBy(u => u.Name).ToList();

        #endregion
    }
}
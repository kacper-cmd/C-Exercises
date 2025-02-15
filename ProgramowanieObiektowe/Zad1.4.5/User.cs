using Microsoft.VisualBasic;

public enum Gender
{
    Male,
    Female
}
public class User
{
    #region Properties
    public Gender Gender { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public int Age { get; set; } 
    #endregion

    #region zad8
    public void AddUsers(List<User> _users, string firstLetter)
    {
        List<User> users = _users.ToList();
        users.AddRange(users);
        var newUsers = new List<User>
        {
           new User { Gender = Gender.Male, Name = "John",  Surname = "Johnny",   Address ="33-304 NS",    Age = 23, Email = "john@gmail.com" },
           new User { Gender = Gender.Female, Name = "Zofia", Surname = "Zofijska", Address ="33-300 NS", Age = 23,Email = "zofia@gmail.com" },
           new User { Gender = Gender.Male, Name = "Michel",Surname = "Ajax",     Address ="33-300 NS",    Age = 23,Email = "michel@gmail.com" },
           new User { Gender = Gender.Male, Name = "Jack",  Surname = "Jacker",   Address ="33-300 NS",    Age = 23,Email = "jack@gmail.com" },
           new User { Gender = Gender.Male, Name = "Denis", Surname = "Deniss",   Address ="33-300 NS",   Age = 23,Email = "denis@gmail.com" },
        };
        _users.AddRange(newUsers);
        var filteredUsers = GetUserNameByFirstLetter(_users, firstLetter);
        DisplayUsers(filteredUsers);
    }
    public void DisplayUsers(List<User> _users)
    {
        foreach (var user in _users)
        {
            Console.WriteLine($"Name : {user.Name}, Surname {user.Surname}, " +
             $"Address {user.Address}, Gender: {user.Gender}, Age: {user.Age}, Email: {user.Email}");
        }
    }
    public List<User> GetUserNameByFirstLetter(List<User> _users, string firstLetter)
    {
        Console.WriteLine($"User with Name start's with {firstLetter}");
        var usersByNameStartingWithGivenLetter = _users.Where(user => 
                                                        user.Name.StartsWith(firstLetter, StringComparison.OrdinalIgnoreCase)).
                                                        ToList();
        return usersByNameStartingWithGivenLetter;
    }
    #endregion
}

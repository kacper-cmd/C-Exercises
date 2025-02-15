using _1_4Metody;

var users = new List<User>()
{
    new User("Filip",Sex.Man,20),
    new User("Marta",Sex.Woman,20),
    new User("Antoni",Sex.Man,45),
    new User("Brunhilda",Sex.Woman,30),
    new User("Hildegarda",Sex.Woman,35),
    new User("Wojciecha",Sex.Woman,42),
    new User("Filip",Sex.Man,100),
    new User("Ambroży",Sex.Man,29),
    new User("Ala",Sex.Woman,40),
    new User("Ala",Sex.Woman,45),
};

Action showUniqueNames = () =>
{
    var names = users.Select(x => x.Name);
    var nameGroups = names.GroupBy(n => n);
    var uniqueNames = nameGroups.Where(ng => ng.Count() == 1).SelectMany(ng => ng);
    Console.WriteLine(string.Join(", ", uniqueNames));
};

Action plus10Years = () =>
{
    users.ForEach(u => u.Age += 10);
    Console.WriteLine(string.Join(Environment.NewLine, users));
};

Action countWomanAndMan = () =>
{
    var womanCount = users.Where(u => u.Sex == Sex.Woman).Count();
    Console.WriteLine($"Liczba Kobiet: {womanCount}");
    var manCount = users.Where(u => u.Sex == Sex.Man).Count();
    Console.WriteLine($"Liczba Mężczyzn: {manCount}");
};

Action sortByNames = () =>
{
    var sortedByNames = users.OrderBy(u => u.Name);
    Console.WriteLine(string.Join(Environment.NewLine, sortedByNames));
};
sortByNames();

Action showNamesWithFirstLetter = () =>
{
    Console.Write("Podaj pierwszą literę imienia użytkownika: ");
    var firstLetterOfName = Console.ReadKey().KeyChar;
    Console.WriteLine();
    var typedUsers = users.Where(
        u =>
        u.Name.StartsWith(firstLetterOfName) ||
        u.Name.StartsWith(char.ToUpper(firstLetterOfName))
        );

    if (!typedUsers.Any())
        Console.WriteLine("Brak użytkowników na podaną literę");
    else
    {
        Console.WriteLine(string.Join(
            Environment.NewLine,
            typedUsers
            )
        );
    }

};

static int Sum(int a, int b)
{
    return a + b;
}

static string Unite(string a, string b)
{
    return string.Concat(a.Concat(b));
}

static Human MakeHuman(string name, string surname, DateTime bornDate)
{
    return new Human
    {
        Name = name,
        Surname = surname,
        BornDate = bornDate,
    };
}
static void Nothing() { }

static void TwoParameters(int a, int b = 0) { }

static void TwoParameters2(int a, int b) { }

static void PlusOneToItems(ref int[] items)
{
    items = items.Select(x => x * 2).ToArray();
}


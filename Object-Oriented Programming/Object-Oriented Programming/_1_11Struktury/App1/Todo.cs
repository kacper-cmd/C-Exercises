public struct Todo
{
    public Todo(
        string title,
        Beggining beggining,
        Ending ending,
        string comment,
        User user
        )
    {
        Title = title;
        Beggining = beggining;
        Ending = ending;
        Comment = comment;
        User = user;

    }
    public string Title { get; init; }

    public Beggining Beggining { get; init; }
    public Ending Ending { get; init; }

    public string Comment { get; init; }
    public User User { get; init; }
}

public struct Beggining
{
    public string BegginingDate { get; init; }
    public string BegginingHour { get; init; }
    public User User { get; init; }
    public Beggining(string date, string hour, User user)
    {
        BegginingDate = date;
        BegginingHour = hour;
        User = user;
    }
}

public struct Ending
{
    public string EndingDate { get; init; }
    public string EndingHour { get; private set; }
    public User User { get; init; }
    public Ending(string date, string hour, User user)
    {
        EndingDate = date;
        EndingHour = hour;
        User = user;
    }
}

public struct User
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public User(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}
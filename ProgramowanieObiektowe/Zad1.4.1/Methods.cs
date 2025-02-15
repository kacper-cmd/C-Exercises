public class Methods
{
    #region zad1
    public int Sum(int a, int b)
    {
        return a + b;
    }
    public string CombineTwoStrings(string string1, string string2)
    {
        return string1 + string2;
    }
    public Project CreateProjectInstance(string name, string description, DateTime startedDate, DateTime finishDate, List<Employee> employees, List<Task> tasks)
    {
        return new Project(name, description, startedDate, finishDate, employees, tasks);
    }
    public void DisplayMessage()
    {
        Console.WriteLine("Nic nie zwracam");
    }
    #endregion

    #region zad2
    public string Scream(string text, string additionalText = "!")
    {
        return text + additionalText;
    }
    #endregion

    #region zad3
    public string ScreamV2(string text)
    {
        string additionalText = "!";
        return text + additionalText;
    } 
    #endregion
}


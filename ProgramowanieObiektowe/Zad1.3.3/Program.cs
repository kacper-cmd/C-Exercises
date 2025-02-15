class Program
{
    static void Main()
    {
        List<Task> tasks = new List<Task>()
        {
            new Task("Realizacja zadan z programowa","In progress"),
            new Task("Rozmowa z klientem", "New")
        };
        List<Employee> employee = new List<Employee>()
        { 
            new Employee("Kacper", "Obrzut", 5000.00m, 20)
        };
        Project project = new Project("Staz", "Staz Kacpra", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(40), employee, tasks);
    }
}
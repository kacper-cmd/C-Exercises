public class Project
{
    #region Fields&Properties
    public List<Task> Tasks { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime FinishDate { get; set; }
    public List<Employee> AssignedEmployees { get; set; }
    #endregion


    #region Constructors
    public Project(string name, string description, DateTime startedDate, DateTime finishDate, List<Employee> employees, List<Task> tasks)
    {
        Tasks = tasks;
        Name = name;
        Description = description;
        StartedDate = startedDate;
        FinishDate = finishDate;
        AssignedEmployees = employees;
    }
    #endregion 
}

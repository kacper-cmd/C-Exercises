public class Task
{
    #region Fields&Properties
    public string Name { get; set; }
    public string Status { get; set; }
    #endregion
    #region Constructor
    public Task(string name, string status)
    {
        Name = name;
        Status = status;
    }
    #endregion

}
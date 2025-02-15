public class Employee
{
    #region Fields&Properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Salary { get; set; }
    public int AvailableHolidaysInDays { get; private set; }

    #endregion
    #region Constructor
    public Employee(string name, string surname, decimal salary, int availableholidaysindays)
    {
        Name = name;
        Surname = surname;
        Salary = salary;
        AvailableHolidaysInDays = availableholidaysindays;
    }
    #endregion
}

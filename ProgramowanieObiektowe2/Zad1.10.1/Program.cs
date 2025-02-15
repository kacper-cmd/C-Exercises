//public class Program
//{
//    public static void Main()
//    {
//        Employee[] employees = new Employee[4];
//        employees[0] = new Employee() { Name = "John", ContractType = 1 };
//        employees[1] = new Employee() { Name = "Bob", ContractType = 1 };
//        employees[2] = new Employee() { Name = "Steve", ContractType = 2 };
//        employees[3] = new Employee() { Name = "Jim", ContractType = 3 };
//        foreach (var employee in employees)
//        {
//            Console.WriteLine("Employee name is : {0} and contract type is {1}", employee.Name, GetContractType(employee.ContractType));
//        }
//    }
//    static string GetContractType(int contract)
//    {
//        switch (contract)
//        {
//            case 1:
//                return "Trial";
//            case 2:
//                return "Internship";
//            case 3:
//                return "Temporary";
//            default:
//                return "Other";
//        }
//    }
//}

//public class Employee
//{
//    public string Name { get; set; }
//    public int ContractType { get; set; }
//}

#region zad1.10.1
public class Program
{
    public static void Main()
    {
        Employee[] employees = new Employee[4];

        employees[0] = new Employee() { Name = "John", ContractType = ContractType.Trial };
        employees[1] = new Employee() { Name = "Bob", ContractType = ContractType.Trial };
        employees[2] = new Employee() { Name = "Steve", ContractType = ContractType.Internship };
        employees[3] = new Employee() { Name = "Jim", ContractType = ContractType.Temporary };

        foreach (var employee in employees)
        {
            Console.WriteLine("Employee name is : {0} and contract type is {1}", employee.Name, employee.ContractType);
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public ContractType ContractType { get; set; }
}

public enum ContractType
{
    Trial = 1,
    Internship = 2,
    Temporary = 3,
    Other = 4
}
#endregion
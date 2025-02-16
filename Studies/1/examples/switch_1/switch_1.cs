using System;
namespace switch_1
{
    class Test
    {
        static void Main(string[] args)
        {            
            // Example 1: calculation of days by given month name

            Console.Write("Enter name of month : ");
            string m = Console.ReadLine();

            byte? result = null;
            switch (m)
            {
                case "April": 
                case "June": 
                case "September":
                case "November": result = 30; break;
                case "January":
                case "March":
                case "May":
                case "July":
                case "August":
                case "October":
                case "December": result = 31; break;
                case "February": if (DateTime.Now.Year % 4 != 0) result = 28; 
                             else result = 29; break;
                default: result = 0; break;
            }
            Console.WriteLine("{0} has {1} days.", m, result);
            Console.ReadLine();

            // Example 2: calculation of salary of a soldier depending on his rank

            Console.Write("Soldier, enter your rank : ");            
            string rank = Console.ReadLine();

            decimal salary = 0;
            switch (rank)
            {
                case "general": salary += 4000; goto case "lieutenant";
                case "lieutenant":
                case "captain": 
                case "major":
                case "colonel": salary += 3000; goto case "sergeant";
                case "sergeant": salary += 3000; break;
                case "private": salary = 2000; break;                
                default: salary = 0; break;
            }
            Console.WriteLine("Salary {0:c}.", salary);
            Console.ReadLine();

        }
    }
}

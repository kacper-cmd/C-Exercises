using System;

namespace classes_3_2
{

    // enumeration definitions
  
    enum MaritalStatus : byte { Single = 1, Married, Divorced, Widowed };

    enum PaymentPeriod { DayOfSale = 0, Month, Quarter = 3, HalfAYear = 6, Year = 12 };

    class Test
    {
        static void Main(string[] args)
        {                          
            Person boss = new Person("Janina","Kloss",true,175,68.55f);            
                     
         // Test of MaritalStatus type (see Person class)
            Console.WriteLine("\n=== Test of enumeration 1 ===\n");             
            boss.Show();
            boss.Marriage();
            boss.Show();

         // Test of PaymentPeriod type (see Invoice class)
            Console.WriteLine("\n=== Test of enumeration 2 ===\n");
            Invoice invoice = new Invoice(DateTime.Now, PaymentPeriod.Quarter);
            Console.WriteLine("\nDate of payment: " + invoice.DateOfPayment());
           
            Console.ReadLine();
        }
    }    

}

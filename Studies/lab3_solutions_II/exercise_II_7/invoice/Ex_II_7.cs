using System;

/*
Create a class named Sale.
In the class define fields representing: product name, amount, sale price.
Implement the class constructor in form: Sale(string pName, int a, decimal sP)
Implement printing method (that is displaying sale on the console).

Create a class named Invoice.
In the class define fields representing: sale date, customer name, sale positions (array of Sale objects) 
assuming that every invoice consists of less than 20 positions.
Implement the class constructor which setting date and buyer (from parameters) and allocate memory 
for array of invoice positions.
Implement addPosition() method which adds sale (position) giving as parameter to the invoice. 
Define two forms of this method:
addPosition(Sale position) and addPosition(string pName, int a, decimal sP)
Implement a printing method (that is displaying a invoice on the console).

Test Invoice class writing a test class with Main method() and appropriate code.
*/

namespace invoice
{        
    class Ex_II_7
    {
        static void Main(string[] args)
        {            
            Sale s1 = new Sale("Tablet AXC", 10, 1600);
            s1.Print();
            Console.WriteLine();
            
            Sale s2 = new Sale("Laptop XYZ", 10, 1600);
            
            Invoice invoice1 = new Invoice(DateTime.Now, "Agata Nowak");
            invoice1.addPosition(s1);
            invoice1.addPosition(s2);
            invoice1.addPosition("Hard disc", 20, 2000);
            invoice1.Print();

            Console.ReadLine();
        }
    }
}

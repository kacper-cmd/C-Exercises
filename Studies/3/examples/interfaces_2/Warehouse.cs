using System;
using product;

namespace interfaces_2
{
    class Warehouse : ICRUDable
    {
        Product[] warehouse = new Product[100];
        int productsCount = 0;
        Product selectedElement;

        public int SelectFromMenu()
        {
            Console.Write("MENU \n1 - Show products\n2 - Add new product\nSelect a command: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void ShowElementsList()
        {
            for (int i = 0; i < productsCount; i++) Console.WriteLine(warehouse[i]);
            Console.WriteLine();
        }

        public void NewElement()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter unit of measure: ");
            string um = Console.ReadLine();
            Console.Write("Enter VAT rate: ");
            float vat = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter margin of profit: ");
            float profit = Convert.ToSingle(Console.ReadLine());

            selectedElement = new Product(name, price, um, DateTime.Now,
                                         vat, profit);
            warehouse[productsCount++] = selectedElement;
        }

        // complete the implementation

        public void SelectElement() { }
        public void EditElement() { }
        public void RemoveElement() { }
        public void ShowElement() { }
    }
        
}

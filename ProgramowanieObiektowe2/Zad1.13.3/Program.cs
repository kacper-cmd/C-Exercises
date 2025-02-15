class Program
{
    static void Main(string[] args)
    {
        Invoice invoice = new  Invoice("FAC-123",DateTime.Now,"KACPER", "Marek" );
        Invoice invoice2 = new Invoice("FAC-125",DateTime.Now.AddDays(-2),"Marian", "Wojtek" );
        Item item  = new Item(1, "PS5", 2000, 240);
        Item item2 = new Item(2, "PS3", 320, 40);
        Item item3 = new Item(3, "PC", 12320, 1240);
        Item item4 = new Item(4, "Apple Vision Pro", 22320, 3240);
        //invoice.AddItem(item);
        //invoice.AddItem(item2);
        invoice  += item;
        invoice  += item2;
        invoice2 += item3;
        invoice2 += item4;

        Console.WriteLine(invoice);
        var invoices = invoice & invoice2;
        Console.WriteLine(invoices);
        
    }
}

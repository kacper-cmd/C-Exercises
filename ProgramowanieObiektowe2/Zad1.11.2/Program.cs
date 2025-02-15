class Program
{
    static void Main(string[] args)
    {
        Invoice invoice = new Invoice("INVOICE-11030", DateTime.Now, "Kacper Obrzut", "Kacper Obrzut");
        invoice.AddInvoiceItem("Program do zarzadania salonem samochodowym", 1, 100.00m, 20.00m, 120.00m);
        invoice.AddInvoiceItem("ENova", 2, 50.00m, 10.00m, 60.00m);
        invoice.AddInvoiceItem("ENova", 1, 200.00m, 40.00m, 240.00m);
        
        Console.WriteLine(invoice);

        invoice.DeleteInvoiceItem("ENova");

        Console.WriteLine(invoice.ToString());
    }
}

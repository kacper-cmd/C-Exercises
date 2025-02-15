class Program
{
    static void Main()
    {
        var invoice = new Invoice
        {
            InvoiceNumber = "Faktura 1/2024/07/18",
            Discount = 0,
            GrossValue = 122,
            IssueDate = DateTime.Now,
            NetValue = 12,
            Purchaser = "Kacper",
            Seller = "Gotoma"
        };
    }
}

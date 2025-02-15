namespace _1_3PolaKlasyZad2
{
    internal class Invoice
    {
        public DateTime DayOfIssue { get; set; }
        public decimal UnitPrice { get; set; }
        private string BuyerName { get; set; }
        private int InvoiceId { get; set; }
        private string NameGood { get; set; }
        private string SellerName { get; set; }
        private decimal TaxesSum { get; set; }
    }
}
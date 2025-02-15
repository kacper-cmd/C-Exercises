public class Invoice
{
    #region Properties

    public string InvoiceNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public string Seller { get; set; }
    public string Purchaser { get; set; }
    public decimal NetValue { get; set; }
    public decimal GrossValue { get; set; }
    public decimal Discount { get; set; }
    #endregion
    #region Constructors
    public Invoice(string invoiceNumber, DateTime issueDate, string seller, string purchaser, decimal netValue, decimal grossValue, decimal discount)
    {
        InvoiceNumber = invoiceNumber;
        IssueDate = issueDate;
        Seller = seller;
        Purchaser = purchaser;
        NetValue = netValue;
        GrossValue = grossValue;
        Discount = discount;
    }
    public Invoice() { } 
    #endregion

}
public struct InvoiceItem
{
    public string Name { get; set; }
    public int InvoiceItemNumber { get; set; }
    public decimal NetValue { get; set; }
    public decimal VATValue { get; set; }
    public decimal GrossValue { get; set; }
    public InvoiceItem(string name, int invoiceItemNumber, decimal netValue, decimal vatValue, decimal grossValue)
    {
        Name = name.ToUpper();
        InvoiceItemNumber = invoiceItemNumber;
        NetValue = netValue;
        VATValue = vatValue;
        GrossValue = grossValue;
    }
}
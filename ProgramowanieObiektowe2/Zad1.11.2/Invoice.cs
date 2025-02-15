using System.Text;
public class Invoice
{
    #region Properties
    public string DocumentNumber { get; set; }
    public DateTime DocumentDate { get; set; }
    public string Recipient { get; set; }
    public string Issuer { get; set; }
    private List<InvoiceItem> InvoiceItems { get; set; }
    #endregion

    #region Constructors
    public Invoice(string documentNumber, DateTime documentDate, string recipient, string issuer)
    {
        DocumentNumber = documentNumber.ToUpper();
        DocumentDate = documentDate;
        Recipient = recipient.ToUpper();
        Issuer = issuer.ToUpper();
        InvoiceItems = new List<InvoiceItem>();
    }
    #endregion

    #region Methods
    public void AddInvoiceItem(string name, int itemNumber, decimal netValue, decimal vatValue, decimal grossValue)
    {
        var invoiceItemExists = InvoiceItems.FirstOrDefault(i => i.Name == name.ToUpper());
        if (invoiceItemExists.Name != null)
        {
            var invoiceItemsIndexToUpdate = InvoiceItems.FindIndex(x => x.Name == name.ToUpper());
            invoiceItemExists.NetValue += netValue;
            invoiceItemExists.VATValue += vatValue;
            invoiceItemExists.GrossValue += grossValue;
            InvoiceItems[invoiceItemsIndexToUpdate] = invoiceItemExists;
        }
        else
        {
            InvoiceItems.Add(new InvoiceItem(name, itemNumber, netValue, vatValue, grossValue));
        }
    }

    public void DeleteInvoiceItem(string name)
    {
        var invoiceItemToRemove = InvoiceItems.FirstOrDefault(i => i.Name == name.ToUpper());
        if (invoiceItemToRemove.Name != null)
        {
            InvoiceItems.Remove(invoiceItemToRemove);
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("------  INVOICE  --------");
        sb.AppendLine($"NUMBER: {DocumentNumber}");
        sb.AppendLine($"DATE: {DocumentDate.ToShortDateString()}");
        sb.AppendLine($"RECIPIENT: {Recipient}");
        sb.AppendLine($"ISSUER: {Issuer}");
        if (InvoiceItems.Count > 0)
        {
            sb.AppendLine("INVOICE ITEMS:");
            foreach (var item in InvoiceItems)
            {
                sb.AppendLine($"NAME: {item.Name}, NUMBER: {item.InvoiceItemNumber}, NET VALUE: {item.NetValue}, VAT VALUE: {item.VATValue}, GROSS VALUE: {item.GrossValue}");
            }
        }
        return sb.ToString();
    }

    #endregion
}
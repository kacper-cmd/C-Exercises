using System.Text;
public class Invoice
{
    #region Properties
    public string DocumentNumber { get; set; }
    public DateTime DocumentDate { get; set; }
    public string Recipient { get; set; }
    public string Issuer { get; set; }
    public List<Item> Items { get; set; }
    public decimal DocumentValue => Items.Sum(item => item.GrossValue);
    #endregion
    
    #region Constructors
    public Invoice(string documentNumber, DateTime documentDate, string recipient, string issuer)
    {
        DocumentNumber = documentNumber.ToUpper();
        DocumentDate = documentDate;
        Recipient = recipient.ToUpper();
        Issuer = issuer.ToUpper();
        Items = new List<Item>();
    }
    #endregion

    #region Methods
    public void AddItem(Item item)
    { 
        var itemExistingWithTheSameName = Items.FirstOrDefault(i => i.Name == item.Name.ToUpper());
        if (itemExistingWithTheSameName != null)
        {
            itemExistingWithTheSameName.NetValue += item.NetValue;
            itemExistingWithTheSameName.VATValue += item.VATValue;
        }
        else
        { 
            Items.Add(item);
        }
    }
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in Items)
        {
            sb.AppendLine(item.ToString());
        }
        var result = $"Number: {DocumentNumber}, Date: {DocumentDate}, Recipient: {Recipient}, " +
            $"Issuer: {Issuer}, Document Value: {DocumentValue:C} " +
            Environment.NewLine + "Items: " + Environment.NewLine + sb;
        return result;
    }
    #endregion

    #region OperatorsOverload
    public static Invoice operator +(Invoice invoice, Item item)
    {
        invoice.AddItem(item);
        return invoice;
    }
    public static Invoice operator -(Invoice invoice, Item item)
    {
        invoice.RemoveItem(item);
        return invoice;
    }
    public static bool operator >(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue > invoice2.DocumentValue;
    }
    public static bool operator <(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue < invoice2.DocumentValue;
    }
    public static bool operator >=(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue >= invoice2.DocumentValue;
    }
    public static bool operator <=(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue <= invoice2.DocumentValue;
    }
    public static bool operator ==(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue == invoice2.DocumentValue;
    }
    public static bool operator !=(Invoice invoice1, Invoice invoice2)
    {
        return invoice1.DocumentValue != invoice2.DocumentValue;
    }
    /// <summary>
    ///     Operator & powinien tworzyć nowy dokument z danymi odbiorcy, osoby wystawiającej(z pierwszego dokumentu)
    ///   i pozycjami z wszystkich dokumentów
    /// </summary>
    public static Invoice operator &(Invoice invoice1, Invoice invoice2)
    {
        var newInvoice = new Invoice(invoice1.DocumentNumber, DateTime.Now, invoice1.Recipient, invoice1.Issuer);

        foreach (var item in invoice1.Items)
        {
            newInvoice += item;
        }
        foreach (var item in invoice2.Items)
        {
            newInvoice += item;
        }

        return newInvoice;
    }
    #endregion
}
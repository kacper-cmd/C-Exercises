public class Item
{
    #region Propeties
    public int Number { get; set; }
    public string Name { get; set; }
    public decimal NetValue { get; set; }
    public decimal VATValue { get; set; }
    public decimal GrossValue => NetValue + VATValue;
    #endregion
    
    #region Constructors
    public Item(int itemNumber, string name, decimal netValue, decimal vatValue)
    {
        Number = itemNumber;
        Name = name.ToUpper();
        NetValue = netValue;
        VATValue = vatValue;
    }
    #endregion

    #region ToStringMethod
    public override string ToString()
    {
        return $"Number: {Number}, Name: {Name}, Net Value: {NetValue:C}," +
            $" VAT Value: {VATValue:C}, Gross Value: {GrossValue:C}";
    }
    #endregion
}

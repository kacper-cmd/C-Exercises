namespace _1_13PrzeladowanieOperatorow
{
    internal class Item
    {
        private string _name;

        public int PositionNumber { get; set; }
        public string Name
        {
            get => _name;
            set { _name = value.ToUpperInvariant(); }
        }
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue
        {
            get => NetValue + VatValue;
        }

        public Item(int positionNumber, string name, decimal netValue, decimal vatValue)
        {
            PositionNumber = positionNumber;
            Name = name;
            NetValue = netValue;
            VatValue = vatValue;
        }

        public override string? ToString()
        {
            return
                    "\n" +
                    $"Numer Pozycji: {PositionNumber}\n" +
                    $"Nazwa Pozycji: {Name}\n" +
                    $"Wartość Netto: {NetValue}\n" +
                    $"Wartość VAT: {VatValue}\n" +
                    $"Wartość Brutto: {GrossValue}\n";
        }
    }
}

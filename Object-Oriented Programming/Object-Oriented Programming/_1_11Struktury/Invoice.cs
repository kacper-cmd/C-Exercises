using System.Text;

namespace _1_11Struktury
{
    internal class Invoice
    {
        public List<Position> Positions { set; get; }
        public string DocumentNumber { get; set; }
        public string DocumentDate { get; set; }
        public string Recipient { get; set; }
        public string Issuer { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Numer Dokumentu: {DocumentNumber}\n" +
                    $"Data Dokumentu: {DocumentDate}\n" +
                    $"Obiorca: {Recipient}\n" +
                    $"Osoba Wystawiająca: {Issuer}\n");
            foreach (var position in Positions)
            {
                sb.AppendLine(
                    "\n" +
                    $"Nazwa Pozycji: {position.Name}\n" +
                    $"Numer Pozycji: {position.Number}\n" +
                    $"Wartość:\n" +
                    $"  Wartość Netto: {position.Value.NetValue}\n" +
                    $"  Wartość VAT: {position.Value.VatValue}\n" +
                    $"  Wartość Brutto: {position.Value.GrossValue}\n");
            }
            return sb.ToString();
        }
    }

    public struct Position
    {
        public string Name { get; set; }
        public Value Value { get; set; }
        public string Number { get; set; }

        public Position(string name, Value value, string number)
        {
            Name = name;
            Value = value;
            Number = number;
        }
    }

    public struct Value
    {
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue { get; set; }

        public Value(decimal netValue, decimal vatValue, decimal grossValue)
        {
            NetValue = netValue;
            VatValue = vatValue;
            GrossValue = grossValue;
        }
    }
}

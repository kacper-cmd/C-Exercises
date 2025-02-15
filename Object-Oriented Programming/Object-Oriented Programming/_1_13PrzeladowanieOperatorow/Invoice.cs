using System.Text;

namespace _1_13PrzeladowanieOperatorow
{
    internal class Invoice
    {
        private string _documentDate;
        private string _recipient;
        private string _documentValue;

        public int DocumentNumber { get; set; }
        public string DocumentDate
        {
            get => _documentDate;
            set
            {
                _documentDate = value.ToUpperInvariant();
            }
        }
        public string Recipient
        {
            get => _recipient;
            set
            {
                _recipient = value.ToUpperInvariant();
            }
        }
        public decimal DocumentValue
        {
            get => Items.Sum(i => i.GrossValue);
        }
        public string Issuer
        {
            get => _documentValue;
            set
            {
                _documentValue = value.ToUpperInvariant();
            }
        }
        public IEnumerable<Item> Items { get; set; }

        public Invoice(int documentNumber, string documentDate, string recipient, string issuer, IEnumerable<Item> items)
        {
            DocumentNumber = documentNumber;
            DocumentDate = documentDate;
            Recipient = recipient;
            Issuer = issuer;
            Items = items;
        }

        public override string? ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.Append(item);
            }
            sb.Replace("\n", "\n    ");
            sb.Insert(0, $"Numer Dokumentu: {DocumentNumber}\n" +
            $"Data Dokumentu: {DocumentDate}\n" +
            $"Obiorca: {Recipient}\n" +
            $"Wartość Dokumentu: {DocumentValue}\n" +
            $"Osoba Wystawiająca: {Issuer}\n");
            return sb.ToString();
        }
        public static IEnumerable<Invoice> operator +(IEnumerable<Invoice> invoices, Invoice invoice)
        {
            return invoices.Append(invoice);

        }
        public static IEnumerable<Invoice> operator -(IEnumerable<Invoice> invoices, Invoice invoice)
        {
            return invoices.SkipWhile(i => i.DocumentNumber.Equals(invoice.DocumentNumber));
        }
        public static bool operator >(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue > invoiceB.DocumentValue;
        }
        public static bool operator <(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue < invoiceB.DocumentValue;
        }
        public static bool operator <=(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue <= invoiceB.DocumentValue;
        }
        public static bool operator >=(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue >= invoiceB.DocumentValue;
        }
        public static bool operator ==(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue == invoiceB.DocumentValue;
        }
        public static bool operator !=(Invoice invoiceA, Invoice invoiceB)
        {
            return invoiceA.DocumentValue != invoiceB.DocumentValue;
        }
        public static Invoice operator &(Invoice invoice, IEnumerable<Invoice> invoices)
        {
            var positions = invoices.SelectMany(x => x.Items);
            return new Invoice(
                invoice.DocumentNumber,
                invoice.DocumentDate,
                invoice.Recipient,
                invoice.Issuer,
                positions
                );
        }
    }
}

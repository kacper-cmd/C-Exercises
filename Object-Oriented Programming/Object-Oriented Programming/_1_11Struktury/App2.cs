namespace _1_11Struktury
{
    internal class App2
    {
        static Invoice AddPosition(Invoice invoice)
        {
            Console.WriteLine("Wpisz dane");
            Console.Write($"Nazwa Pozycji: ");
            var positionName = Console.ReadLine().ToUpper();
            Console.Write($"Numer Pozycji: ");
            var positionNumber = Console.ReadLine().ToUpper();
            Console.Write($"Wartość: \n");
            Console.Write($"  Wartość Netto: ");
            decimal netValue;
            var netValueParsingSuccess = decimal.TryParse(Console.ReadLine(), out netValue);
            if (!netValueParsingSuccess)
            {
                Console.WriteLine("Wrong data!");
                Thread.Sleep(1000);
                Console.Clear();
                return invoice;
            }
            Console.Write($"  Wartość VAT: ");
            decimal vatValue;
            var vatValueParsingSuccess = decimal.TryParse(Console.ReadLine(), out vatValue);
            if (!vatValueParsingSuccess)
            {
                Console.WriteLine("Wrong data!");
                Thread.Sleep(1000);
                Console.Clear();
                return invoice;
            }
            Console.Write($"  Wartość Brutto: ");
            decimal grossValue;
            var grossValueParsingSuccess = decimal.TryParse(Console.ReadLine(), out grossValue);
            if (!grossValueParsingSuccess)
            {
                Console.WriteLine("Wrong data!");
                Thread.Sleep(1000);
                Console.Clear();
                return invoice;
            }



            if (invoice.Positions.Any(p => p.Name.Equals(positionName)))
            {
                var oldPosition = invoice.Positions.Find(p => p.Name.Equals(positionName));
                var newNetValue = oldPosition.Value.NetValue + netValue;
                var newVatValue = oldPosition.Value.VatValue + vatValue;
                var newGrossValue = oldPosition.Value.GrossValue + grossValue;
                var newValue = new Value(newNetValue, newVatValue, newGrossValue);
                var newPosition = new Position(positionName, newValue, positionNumber);
                invoice.Positions.Remove(oldPosition);
                invoice.Positions.Add(newPosition);
                Console.Clear();
                return invoice;
            }
            var value = new Value(netValue, vatValue, grossValue);
            var position = new Position(positionName, value, positionNumber);
            invoice.Positions.Add(position);
            Console.Clear();
            return invoice;
        }
        static Invoice DeletePosition(Invoice invoice)
        {
            Console.WriteLine("Wpisz dane");
            Console.Write($"Nazwa Pozycji: ");
            var positionName = Console.ReadLine().ToUpper();
            invoice.Positions.RemoveAll(p => p.Name == positionName);
            Console.Clear();
            return invoice;
        }

        static void DisplayPositions(Invoice invoice)
        {
            Console.WriteLine(invoice.ToString());
            Console.WriteLine("\nKlinkij dowolny przycisk, aby wrócić do menu");
            var optionNumber = Console.ReadKey().KeyChar;
            Console.Clear();
        }

        static Position CheckAndChange(Position position, Position newPosition)
        {
            var positionName = position.Name;
            var positionNumber = position.Number;
            if (position.Name.Equals(newPosition.Name))
            {
                var newVatValue = position.Value.VatValue + newPosition.Value.VatValue;
                var newNetValue = position.Value.NetValue + newPosition.Value.NetValue;
                var newGrossValue = position.Value.GrossValue + newPosition.Value.GrossValue;
                var value = new Value(newNetValue, newVatValue, newGrossValue);
                return new Position(positionName, value, positionNumber);
            }
            return position;
        }

        public static void Start()
        {
            var invoice = new Invoice()
            {
                Issuer = "Grzegorz",
                Recipient = "Albert",
                DocumentDate = "22.07.2022",
                DocumentNumber = "111111",
                Positions = new List<Position>()
            };

            while (true)
            {
                Console.WriteLine("Dodaj Pozycję - 1");
                Console.WriteLine("Usuń Pozycję - 2");
                Console.WriteLine("Pokaż wszystkie pozycje - 3");
                Console.WriteLine("Zamknij aplikację - inny klawisz");
                var optionNumber = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (optionNumber)
                {
                    case '1':
                        invoice = AddPosition(invoice);
                        break;
                    case '2':
                        invoice = DeletePosition(invoice);
                        break;
                    case '3':
                        DisplayPositions(invoice);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}

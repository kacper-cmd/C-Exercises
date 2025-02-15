using System.Globalization;
class Program
{
    static void Main()
    {
        try
        {
            decimal itemPrice = GetPrice();
            int numberOfInstallments = GetNumberOfInstallments();

            int paymentDay = GetPaymentDay();

            decimal customerInitialPayment = GetCustomerInitialPayment(itemPrice);

            decimal interestRate = GetInterestRate(numberOfInstallments);

            decimal loanAmount = itemPrice - customerInitialPayment;//kredyt

            decimal amountInterest = loanAmount * interestRate;// odsetki
            decimal amountToBePaidBack = loanAmount + amountInterest;//do splaty
            decimal installment = amountToBePaidBack / numberOfInstallments;//rata

            Console.WriteLine($"\nKwota kredytu: {loanAmount:C}");
            Console.WriteLine($"Kwota do spłaty (z odsetkami): {amountToBePaidBack:C}");
            Console.WriteLine($"Wysokość miesięcznej raty: {installment:C}\n");

            CultureInfo polishCulture = new CultureInfo("pl-PL");
            DateTime dateOfFirstInstalment = DateTime.Now.AddMonths(1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("|===================================|");
            for (int i = 0; i < numberOfInstallments; i++)
            {
                DateTime dateOfPayment = new DateTime(dateOfFirstInstalment.Year, dateOfFirstInstalment.Month, paymentDay);
                if (dateOfPayment.DayOfWeek == DayOfWeek.Saturday || dateOfPayment.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateOfPayment = dateOfPayment.AddDays(1);
                }
                string month = dateOfPayment.ToString("MMMM", polishCulture);//"d MMMM yyyy"
                Console.WriteLine($"| {paymentDay} - {month} - {dateOfPayment.Year} r.: {installment:C} |");
                Console.WriteLine("----------------------------------");
                dateOfFirstInstalment = dateOfFirstInstalment.AddMonths(1);
            }
            Console.WriteLine("|===================================|");
            Console.ResetColor();
            Console.ReadKey();
        }
        catch (FormatException ex)

        {
            Console.WriteLine("Podano nieprawidłowe dane");
        }
        
    }
    static decimal GetPrice()
    {
        decimal price;
        while (true)
        {
            Console.WriteLine("Podaj cenę towaru:");
            if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
            {
                return price;
            }
            Console.WriteLine(" ! Niepoprawna cena !. Wprowadz ponownie.");
        }
    }
    static int GetNumberOfInstallments()
    {
        int numberOfInstallments;
        while (true)
        {
            Console.WriteLine("Podaj liczbę rat (od 2 do 24):");
            if (int.TryParse(Console.ReadLine(), out numberOfInstallments) && numberOfInstallments >= 2 && numberOfInstallments <= 24)
            {
                return numberOfInstallments;
            }
            Console.WriteLine("! Niepoprawna liczba rat !. Wprowadz ponownie.");
        }
    }

    static int GetPaymentDay()
    {
        int paymentDay;
        while (true)
        {
            Console.WriteLine("Podaj dzień płatności raty (1-31): ");
            if (int.TryParse(Console.ReadLine(), out paymentDay) && paymentDay >= 1 && paymentDay <= 31)
            {
                return paymentDay;
            }
            Console.WriteLine("! Niepoprawny dzień płatności !. Wprowadz ponownie.");
        }
    }

    static decimal GetCustomerInitialPayment(decimal price)
    {
        decimal initialPayment;
        while (true)
        {
            Console.WriteLine("Podaj wpłatę klienta (od 0 zł): ");
            if (decimal.TryParse(Console.ReadLine(), out initialPayment) && initialPayment >= 0 && initialPayment <= price)
            {
                return initialPayment;
            }
            Console.WriteLine("!Niepoprawna wpłata klienta !. Wprowadz ponownie.");
        }
    }

    static decimal GetInterestRate(int numberOfInstallments)
    {
        if (numberOfInstallments >= 2 && numberOfInstallments <= 8)
        {
            return 0m;
        }
        else if (numberOfInstallments >= 9 && numberOfInstallments <= 12)
        {
            return 0.05m;
        }
        else
        {
            return 0.08m;
        }
    }
}



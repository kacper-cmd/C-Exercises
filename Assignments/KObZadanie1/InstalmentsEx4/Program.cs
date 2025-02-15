using System.Globalization;
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Podaj cenę towaru: ");
            decimal itemPrice = decimal.Parse(Console.ReadLine());
            int numberOfInstallments;
            do
            {
                Console.Write("Podaj liczbę rat (od 2 do 24): ");
                numberOfInstallments = int.Parse(Console.ReadLine());
            } while (numberOfInstallments < 2 || numberOfInstallments > 24);

            int paymentDay;
            do
            {
                Console.Write("Podaj dzień płatności raty (1-31): ");
                paymentDay = int.Parse(Console.ReadLine());
            } while (paymentDay < 1 || paymentDay > 31);

            Console.Write("Podaj wpłatę klienta (od 0 zł): ");
            decimal customerInitialPayment;
            do
            {
                customerInitialPayment = decimal.Parse(Console.ReadLine());
            } while (customerInitialPayment < 0);

            decimal loanAmount = itemPrice - customerInitialPayment;//kredyt

            decimal interestRates; //oprocentowanie
            if (numberOfInstallments >= 2 && numberOfInstallments <= 8)
            {
                interestRates = 0m;
            }
            else if (numberOfInstallments >= 9 && numberOfInstallments <= 12)
            {
                interestRates = 0.05m;
            }
            else
            {
                interestRates = 0.08m;
            }

            decimal amountInterest = loanAmount * interestRates;// odsetki
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
}



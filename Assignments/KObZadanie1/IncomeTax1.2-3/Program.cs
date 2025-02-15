namespace IncomeTax1
{
    class Program
    {
        const decimal BASE_INCOME = 85528m;
        const decimal TAX_PERCENTAGE_BASE = 0.18m;
        const decimal TAX_PERCENTAGE_SECOND = 0.32m;
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz swój dochód w złotówkach:");
            string userIncome = Console.ReadLine();
            if (decimal.TryParse(userIncome, out decimal income))
            {
                decimal tax = CalculateTax(income);
                Console.WriteLine($"Podatek do zapłacenia wynosi: {tax:C}");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format. Wprowadź prawidłową kwotę dochodu.");
            }
        }
        static decimal CalculateTax(decimal income)
        {
            if (income <= BASE_INCOME)
            {
                decimal taxForIncome = income * TAX_PERCENTAGE_BASE;
                return taxForIncome;
            }
            else
            {   // powyżej kwoty 85 528 zł za każdą złotówkę ponad podatek wynosi 32 %  
                decimal taxForBaseIncome = BASE_INCOME * TAX_PERCENTAGE_BASE;
                decimal excessIncome = income - BASE_INCOME;
                decimal taxForExcessIncome = excessIncome * TAX_PERCENTAGE_SECOND;
                decimal totalTax = taxForBaseIncome + taxForExcessIncome;
                return totalTax;
            }
        }
    }
}

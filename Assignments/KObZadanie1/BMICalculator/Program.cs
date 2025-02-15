namespace BMICalculator
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                double height = GetHeight();
                double weight = GetWeight();
                double BMI = CalculateBMI(weight, height);
                Console.WriteLine($"Twoje BMI wynosi: {BMI:F4}");
                string BMIDetails = DisplayDetailsAboutBMI(BMI);
                Console.WriteLine(BMIDetails);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Wprowadzono niepoprawne dane !!");
            }
        }

        static double GetWeight()
        {
            Console.WriteLine("Podaj ile wazysz (w kilogramach):");
            string weightFromUser = Console.ReadLine();
            if (!double.TryParse(weightFromUser, out double weight) || weight <= 0)
            {
                throw new FormatException();
            }
            return weight;
        }

        static double GetHeight()
        {
            Console.WriteLine("Podaj wzrost w metrach:");
            string heightFromUser = Console.ReadLine();
            if (!double.TryParse(heightFromUser, out double height) || height <= 0)
            {
                throw new FormatException();
            }
            return height;
        }

        static double CalculateBMI(double weight, double height)
        {
            double bmi = weight / (height * height);
            return bmi;
        }
        static string DisplayDetailsAboutBMI(double bmi)
        {
            if (bmi < 16.0)
            {
                return "Wygłodzenie";
            }
            else if (bmi < 17.0)
            {
                return "Wychudzenie";
            }
            else if (bmi < 18.5)
            {
                return "Niedowaga";
            }
            else if (bmi < 25.0)
            {
                return "Pożądana masa ciała - jest OK :)";
            }
            else if (bmi < 30.0)
            {
                return "Nadwaga";
            }
            else if (bmi < 35.0)
            {
                return "I stopień otyłości";
            }
            else if (bmi < 40.0)
            {
                return "II stopień otyłości (duza)";
            }
            else
            {
                return "III stopień otyłości (chorobliwa)";
            }
        }
    }
}

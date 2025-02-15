using System.Globalization;

namespace _1_8ElementyStatyczne
{
    internal static class DateConverter
    {
        public static int FailedAmericanConversionCounter = 0;
        public static int FailedFrenchConversionCounter = 0;
        public static int FailedPolishConversionCounter = 0;
        public static DateTime ConvertAmericanDate(string dateText)
        {
            return ConvertDate(dateText, "us-US", ref FailedAmericanConversionCounter);
        }
        public static DateTime ConvertFrenchDate(string dateText)
        {
            return ConvertDate(dateText, "fr-FR", ref FailedFrenchConversionCounter);
        }
        public static DateTime ConvertPolishDate(string dateText)
        {
            return ConvertDate(dateText, "pl-PL", ref FailedPolishConversionCounter);
        }
        private static DateTime ConvertDate(string dateText, string cultureText, ref int counter)
        {
            try
            {
                var date = DateTime.Parse(dateText, new CultureInfo(cultureText, false));
                Console.WriteLine($"Udało się przekonwertować!\n");
                return date;
            }
            catch (Exception ex)
            {
                counter++;
                Console.WriteLine($"Nie Udało się przekonwertować!");
                Console.WriteLine($"Łączna liczba nieudanych prób z formatem {cultureText}: {counter}\n");
                return new DateTime();
            }
        }
    }
}

using System.Globalization;
namespace Zad1._8._2ElementyStatyczne.Helpers;
//https://stackoverflow.com/questions/11999912/datetime-tryparseexact-rejecting-valid-formats
public static class DateFormatConverter
{
    #region StaticFields

    private static int usCorrectCounter = 0;
    private static int usIncorrectCounter = 0;
    private static int plCorrectCounter = 0;
    private static int plIncorrectCounter = 0;
    private static int frCorrectCounter = 0;
    private static int frIncorrectCounter = 0;

    #endregion

    #region StaticMethods
    public static DateTime? ConvertToDateInUSFormat(string dateInStringFormat)
    {
        string usFormat = "MM/dd/yyyy";
        IFormatProvider provider = new CultureInfo("en-US");//CultureInfo.InvariantCulture;
        DateTime parsedDate;
        DateTimeStyles styles = DateTimeStyles.None;

        bool isValidDate = DateTime.TryParseExact(dateInStringFormat, usFormat,
            provider, styles, out parsedDate);

        if (isValidDate)
        {
            usCorrectCounter++;
            return parsedDate;
        }
        else
        {
            usIncorrectCounter++;
            return null;
        }
    }

    public static DateTime? ConvertToDateInPLFormat(string dateInStringFormat)
    {
        string plFormat = "dd.MM.yyyy";
        IFormatProvider provider = new CultureInfo("pl-PL");
        DateTime parsedDate;
        DateTimeStyles styles = DateTimeStyles.None;

        bool isValidDate = DateTime.TryParseExact(dateInStringFormat, plFormat,
            provider, styles, out parsedDate);

        if (isValidDate)
        {
            plCorrectCounter++;
            return parsedDate;
        }
        else
        {
            plIncorrectCounter++;
            return null;
        }
    }
    //https://code-maze.com/csharp-convert-string-to-datetime/
    public static DateTime? ConvertToDateInFRFormat(string dateInStringFormat)
    {
        string frFormat = "dd/MM/yyyy";
        IFormatProvider provider = new CultureInfo("fr-FR");
        DateTime parsedDate;
        DateTimeStyles styles = DateTimeStyles.None;

        bool isValidDate = DateTime.TryParseExact(dateInStringFormat, frFormat,
            provider, styles, out parsedDate);

        if (isValidDate)
        {
            frCorrectCounter++;
            return parsedDate;
        }
        else
        {
            frIncorrectCounter++;
            return null;
        }
    }
    
    public static void DisplayDetails()
    {
        Console.WriteLine($"US Format: Correct convertion -> {usCorrectCounter}, Incorrect convertion -> {usIncorrectCounter}");
        Console.WriteLine($"PL Format: Correct convertion -> {plCorrectCounter}, Incorrect convertion -> {plIncorrectCounter}");
        Console.WriteLine($"FR Format: Correct convertion -> {frCorrectCounter}, Incorrect convertion -> {frIncorrectCounter}");
    }

    #endregion
}
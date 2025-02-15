namespace KonwersjeDanychZad2.Helpers;
public class DateValidator
{
    public static bool isValidMonth(string input, out int month)
    {
        if (int.TryParse(input, out month) && month >= 1 && month <= 12)
        {
            return true;
        }
        month = 0;
        return false;
    }
    public static bool isValidHour(string input, out int hour)
    {
        if (int.TryParse(input, out hour) && hour >= 0 && hour <= 24)
        {
            return true;
        }
        hour = 0;
        return false;
    }
    public static bool isValidMinute(string input, out int minute)
    {
        if (int.TryParse(input, out minute) && minute >= 0 && minute <= 60)
        {
            return true;
        }
        minute = 0;
        return false;
    }
}

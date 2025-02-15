namespace FunkcjeZad1.Extensions;
public static class TimeSpanExtension
{
    public static string ToCustomString(this TimeSpan span)
    {
        var dayText = span.Days == 1 ? "dzień" : "dni";
        var hoursText = span.Hours == 1 ? "godzina" : "godziny";
        var minutText = span.Minutes == 1 ? "minuta" : "minut";
        return string.Format("{0:0} {1} : {2:00} {3} : {4:00} {5}", span.Days, dayText, span.Hours, hoursText, span.Minutes, minutText);
    }
}

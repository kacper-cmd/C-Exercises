public class TimeExample
{
    #region Fields
    private int hours;
    private int minutes;
    private int seconds;
    #endregion

    #region Constructors
    public TimeExample(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }
    #endregion
    public override string ToString()
    {
        return $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    #region OperatorsOverloading

    //https://stackoverflow.com/questions/25461585/operator-overloading-equals
    public static bool operator ==(TimeExample t1, TimeExample t2)
    {
        if (t1 is null) return false;
        if (t2 is null) return false;
        if (ReferenceEquals(t1, t2)) return true;
        return t1.hours == t2.hours && t1.minutes == t2.minutes && t1.seconds == t2.seconds;
    }
    public static bool operator !=(TimeExample t1, TimeExample t2)
    {
        return !(t1 == t2);
    }
    public static bool operator >(TimeExample t1, TimeExample t2)
    {
        if (t1.hours > t2.hours) return true;
        if (t1.hours < t2.hours) return false;
        if (t1.minutes > t2.minutes) return true;
        if (t1.minutes < t2.minutes) return false;
        return t1.seconds > t2.seconds;
    }
    public static bool operator <(TimeExample t1, TimeExample t2)
    {
        if (t1.hours < t2.hours) return true;
        if (t1.hours > t2.hours) return false;
        if (t1.minutes < t2.minutes) return true;
        if (t1.minutes > t2.minutes) return false;
        return t1.seconds < t2.seconds;
    }
    public static TimeExample operator --(TimeExample t)
    {
        TimeSpan timeSpanMinus = new TimeSpan(t.hours, t.minutes, --t.seconds);
        t.hours = timeSpanMinus.Hours;
        t.minutes = timeSpanMinus.Minutes;
        t.seconds = timeSpanMinus.Seconds;
        return t;
    }
    public static TimeExample operator ++(TimeExample t)
    {
        TimeSpan timeSpanPlus = new TimeSpan(t.hours, t.minutes, ++t.seconds);
        t.hours = timeSpanPlus.Hours;
        t.minutes = timeSpanPlus.Minutes;
        t.seconds = timeSpanPlus.Seconds;
        return t;
    }
    #endregion
}
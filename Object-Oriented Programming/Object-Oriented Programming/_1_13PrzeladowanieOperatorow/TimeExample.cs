namespace _1_3PrzeladowanieOperatorow
{
    internal class TimeExample
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeExample(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string? ToString()
        {
            return $"{(Hours > 9 ? Hours : $"0{Hours}")}:" +
                $"{(Minutes > 9 ? Minutes : $"0{Minutes}")}:" +
                $"{(Seconds > 9 ? Seconds : $"0{Seconds}")}";
        }
        public static bool operator ==(TimeExample a, TimeExample b)
            => a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds;
        public static bool operator !=(TimeExample a, TimeExample b)
            => !(a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds);
        public static bool operator >(TimeExample a, TimeExample b)
        {
            if (a.Hours > b.Hours)
                return true;
            if (a.Minutes > b.Minutes)
                return true;
            if (a.Seconds > b.Seconds)
                return true;
            return false;
        }
        public static bool operator <(TimeExample a, TimeExample b)
        {
            if (a.Hours < b.Hours)
                return true;
            if (a.Minutes < b.Minutes)
                return true;
            if (a.Seconds < b.Seconds)
                return true;
            return false;
        }
        public static TimeExample operator ++(TimeExample a)
            => new TimeExample(a.Minutes, a.Hours, a.Seconds++);
        public static TimeExample operator --(TimeExample a)
            => new TimeExample(a.Minutes, a.Hours, a.Seconds--);

    }
}

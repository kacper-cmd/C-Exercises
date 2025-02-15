namespace _1_8ElementyStatyczne
{
    internal static class Helper
    {
        public static void ShowWorkingDaysBetweenDates(DateTime date1, DateTime date2)
        {
            Func<DateTime, bool> isWorkingDay = currendDate =>
            (
                currendDate.DayOfWeek == DayOfWeek.Saturday ||
                currendDate.DayOfWeek == DayOfWeek.Sunday
            );

            var wrokingDaysNumber = Enumerable.Range(0, 1 + (date2 - date1).Days)
                .Count(d => isWorkingDay(date1.AddDays(d)));
            Console.WriteLine(wrokingDaysNumber);
        }
        public static void DupTheTextInFile(string pathToFile)
        {

            var text = File.ReadAllText(pathToFile);
            var dupedText = string.Join(
                ' ',
                text.Split(' ').Select
                (
                    w => (
                        w.EndsWith('a') || w.EndsWith('e') || w.EndsWith('o') ?
                        w = "dupa" : w
                        )
                    )
            );
            File.WriteAllText(pathToFile, dupedText);
        }
        public static void UndupTheTextInFile(string pathToFile)
        {
            var random = new Random();
            var words = new string[] { "poniedziałek", "drzewo", "baran", "samochód" };
            var text = File.ReadAllText(pathToFile);
            var undupedText = string.Join(
                ' ',
                text.Split(' ').Select
                (
                    w => (
                        w.Equals("dupa") ?
                        words[random.Next(0, 4)] : w
                        )
                    )
            );
            File.WriteAllText(pathToFile, undupedText);
        }
    }
}

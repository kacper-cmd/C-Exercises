using FunkcjeZad1.Extensions;
class Program
{
    #region Fields&Properties
    static Dictionary<int, string> tasksList = new Dictionary<int, string>
    {
        { 1, "Ostyluj lilu layout" },
        { 2, "Popraw paddingi" },
        { 3, "Napisz Program liczacy BMI" }
    };
    static Dictionary<int, TimeSpan> timeSpent = new Dictionary<int, TimeSpan>
    {
        { 1, TimeSpan.Zero },
        { 2, TimeSpan.Zero },
        { 3, TimeSpan.Zero }
    };
    #endregion
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Wybierz zadanie ktoremu chcesz zalogowac czas pracy (podaj liczbe Lp):");
            foreach (var task in tasksList)
            {
                Console.WriteLine($"Lp: {task.Key}. {task.Value}");
            }
            var taskUserChoice = Console.ReadLine();

            if (int.TryParse(taskUserChoice, out int taskNumber) && tasksList.ContainsKey(taskNumber))
            {
                DisplayPossibleOptions();
                string input = Console.ReadLine();
                var success = ProcessUserChoice(taskNumber, input);
                if (!success)
                {
                    Console.WriteLine($"Blad podczas logowania czasu dla zadania: {tasksList[taskNumber]}");
                }
               
                Console.WriteLine($"Czas spedzony na zadaniu-> {tasksList[taskNumber]}: {timeSpent[taskNumber].ToCustomString()}");
            }
            else
            {
                Console.WriteLine("Nieprawidlowy numer zadania !!.");
            }
        }
    }
    #region Functions
    static void DisplayPossibleOptions()
    {
        Console.WriteLine("Wprowadz czas do zalogowania:");
        Console.WriteLine("a) dni, godziny, minuty");
        Console.WriteLine("b) godziny, minuty");
        Console.WriteLine("c) minuty");
    }
    static bool ProcessUserChoice(int taskNumber, string inputString)
    {
        bool success = false;

        switch (inputString.ToLower())
        {
            case "a":
                success = LogTime(taskNumber, true, true, true);
                return success;
            case "b":
                success = LogTime(taskNumber, false, true, true);
                return success;
            case "c":
                success = LogTime(taskNumber, false, false, true);
                return success;
            default:
                Console.WriteLine("Nieprawidlowy wynbor ");
                return success;
        }
    }
    static bool LogTime(int taskNumber, bool askForDays, bool askForHours, bool askForMinutes)
    {
        int days = 0, hours = 0, minutes = 0;
        try
        {
            if (askForDays)
            {
                Console.Write("Wprowadz dni: ");
                if (!int.TryParse(Console.ReadLine(), out days) || days < 0)
                {
                    throw new ArgumentException("Nieprawidlowy dzien.");
                }
            }

            if (askForHours)
            {
                Console.Write("Wprowadz godziny: ");
                if (!int.TryParse(Console.ReadLine(), out hours) || hours < 0 || hours >= 24)
                {
                    throw new ArgumentException("Godzina musi byc miedzy 0 a 24.");
                }
            }

            if (askForMinutes)
            {
                Console.Write("Wprowadz minuty: ");
                if (!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || minutes >= 60)
                {
                    throw new ArgumentException("Minuta musi byc miedzy 0 a 60");
                }
            }

            TimeSpan timeLogged = WorkLog(taskNumber, days, hours, minutes);
            timeSpent[taskNumber] += timeLogged;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Blad -> {ex.Message}");
            return false;
        }
    }
    static TimeSpan WorkLog(int taskNumber, int days, int hours, int minutes)
    {
        return new TimeSpan(days, hours, minutes, 0);
    }
    #endregion
}


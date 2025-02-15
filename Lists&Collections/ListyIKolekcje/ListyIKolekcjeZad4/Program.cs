class Program
{
    static void Main()
    {
        List<int> numbers = GenerateNumberList();
        
        //Dictionary<int, int> freqs = CountOcurrenceOfDigits(numbers);
        Dictionary<char, int> digitCount = CountDigits(numbers);

        foreach (var kvp in digitCount)
        {
            Console.WriteLine($"Cyfra: {kvp.Key}, Wystąpiła : {kvp.Value}");
        }
    }
    static List<int> GenerateNumberList()
    {
        return new List<int> { 123, 456, 789, 101, 202, 303, 404, 505 };
    }
    static Dictionary<char, int> CountDigits(List<int> numbers)
    {
        return numbers
                .SelectMany(num => num.ToString())
                .GroupBy(digit => digit)
                .ToDictionary(group => group.Key, group => group.Count());
    }
    //test 
    static Dictionary<int, int> CountOcurrenceOfDigits(List<int> numbers)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();

        foreach (int dig in numbers)
        {
            string numberInString = dig.ToString();
            foreach (char charDigit in numberInString)
            {
                int digit = charDigit - 48;//char code 48 of '0'
                if (dic.ContainsKey(digit))
                {
                    dic[digit]++;
                }
                else
                {
                    dic[digit] = 1;
                }
            }
        }
        return dic;
    }
    private static Dictionary<char, int> CountCharacters(string text)
    {
        var countCharacters = new Dictionary<char, int>();

        foreach (var mark in text)
        {
            if (mark != ' ')
            {
                if (!countCharacters.ContainsKey(mark))
                    countCharacters.Add(mark, 1);
                else
                    countCharacters[mark]++;
            }
        }
        return countCharacters;
    }
    private static Dictionary<char, int> CountDigits(string text)
    {
        var countDigits = new Dictionary<char, int>();

        foreach (var mark in text)
        {
            if (char.IsDigit(mark)) // Sprawdza, czy znak to cyfra (0-9)
            {
                if (!countDigits.ContainsKey(mark))
                    countDigits.Add(mark, 1);
                else
                    countDigits[mark]++;
            }
        }
        return countDigits;
    }
    private static Dictionary<int, int> CountDigits2(string text)
    {
        var countDigits = new Dictionary<int, int>();

        foreach (var mark in text)
        {
            if (char.IsDigit(mark)) //  (0-9)
            {
                int digit = mark - '0'; // Konwersja char na int

                if (!countDigits.ContainsKey(digit))
                    countDigits.Add(digit, 1);
                else
                    countDigits[digit]++;
            }
        }
        return countDigits;
    }


}
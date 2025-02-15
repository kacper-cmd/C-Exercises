using Zad1._8._3ElementyStatyczne.Config;

namespace Zad1._8._3ElementyStatyczne.Helpers;
public static class OperationHelper
{
    #region a)
    public static int GetWorkingDays(DateTime start, DateTime end)
    {
        if (start > end)
            throw new ArgumentException("Start must be > than end date");

        int workingDays = 0;
        DateTime currentDate = start;

        while (currentDate <= end)
        {
            if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                workingDays++;
            }
            currentDate = currentDate.AddDays(1);
        }

        return workingDays;
    }

    #endregion

    #region b)
    public static string ConcatenateStringEverySecondLetterIsUppercase(string firstText, string secoundText)
    {
        if (string.IsNullOrWhiteSpace(firstText))
            throw new ArgumentException("First text not provided", nameof(firstText));

        if (string.IsNullOrWhiteSpace(secoundText))
            throw new ArgumentException("Secound text not provided", nameof(secoundText));

        string concatenatedStringLowerCase = (firstText + secoundText).ToLower();

        char[] resultCharArray = concatenatedStringLowerCase.ToCharArray();

        for (int i = 1; i < resultCharArray.Length; i += 2)
        {
            resultCharArray[i] = char.ToUpper(resultCharArray[i]);
        }
        string resultString = new string(resultCharArray);
        return resultString;
    }
    #endregion
    
    #region c)
    public static void ReplaceEndingOfFileWithWord(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException(nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {nameof(filePath)}");
     
        string[] fileLines = File.ReadAllLines(filePath);
        string[] resultContent = new string[fileLines.Length];
        
        for (int i = 0; i < fileLines.Length; i++)
        {
            string line = fileLines[i];
            string[] words = line.Split(' ');
            for (int j = 0; j < words.Length; j++)
            {
                string word = words[j];
                if (word.EndsWith("a") || word.EndsWith("e") || word.EndsWith("o"))
                {
                    word = Constants.wordToReplace;
                }
            }
            resultContent[i] = string.Join(" ", words);
        }
        File.WriteAllLines(filePath, resultContent);
    }

    #endregion
    #region d)

    public static void ReplaceWordWithRandomWord(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException(nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {nameof(filePath)}");

        string[] randomWords = Constants.randomWords;
        Random random = new Random();

        string[] fileLines = File.ReadAllLines(filePath);
        string[] resultContent = new string[fileLines.Length];

        for (int i = 0; i < fileLines.Length; i++)
        {
            string line = fileLines[i];
            string[] words = line.Split(' ');
            
            for (int j = 0; j < words.Length; j++)
            {
                var word = words[j];
                if (word == Constants.wordToReplace)
                {
                    word = randomWords[random.Next(randomWords.Length)];
                }
            }
            resultContent[i] = string.Join(" ", words);
        }
        File.WriteAllLines(filePath, resultContent);
    }



    #endregion
}
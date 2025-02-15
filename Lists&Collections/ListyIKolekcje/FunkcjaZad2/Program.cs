using System.Text.RegularExpressions;
public class Program
{
    public static void Main(string[] args)
    {
        string tekst = $"Dzisiaj jest {DateTime.Now.Date}. Jestem na stazu w GOTOMA Software House. I programuje w C#";
        Console.WriteLine(tekst + Environment.NewLine);
        string[] result = SplitText(tekst);

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
    #region Functions
    public static string[] SplitText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return Array.Empty<string>();
        } 
        char[] separators = [' ', '\t', '\n', '\r'];
        char[]? separators2 = null;
     
        string[] words = text.Split(separators2, StringSplitOptions.RemoveEmptyEntries);

        Regex regex = new Regex(@"\s");
        string[] words2 = regex.Split(text);

        return words;
    }
    #endregion
}
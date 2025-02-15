using Zad1._8._3ElementyStatyczne.Config;
using Zad1._8._3ElementyStatyczne.Helpers;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            //a)
            DateTime startDate = new DateTime(2024, 7, 1);
            DateTime endDate = new DateTime(2024, 7, 26);
            var workingDays = OperationHelper.GetWorkingDays(startDate, endDate);
            string day = workingDays >= 1 ? "days" : "day";

            Console.WriteLine("Working days between {0} and {1}: {2} -> {3}",
                startDate.ToShortDateString(),
                endDate.ToShortDateString(),
                workingDays,
                day);

            //b)
            string firstText = "Kacper";
            string secoundText = "Obrzut";
            var concatenatedText = OperationHelper.
                ConcatenateStringEverySecondLetterIsUppercase(firstText, secoundText);

            Console.WriteLine("Concatenated text: {0}", concatenatedText);

            //c)
            OperationHelper.ReplaceEndingOfFileWithWord(Constants.filePath);

            //d)
            OperationHelper.ReplaceWordWithRandomWord(Constants.filePath);
            
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
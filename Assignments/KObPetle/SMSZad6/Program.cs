using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wpisz SMS:");
         
        //string sms = Console.ReadLine();
        string sms = "Dzisiaj jest czwartek, \r\n\r\nA jutro bedzie piatek. ";
        string convertedSMS = ConvertSMS(sms);
        
        Console.WriteLine("Przekształcony SMS:");
        Console.WriteLine(convertedSMS);
    }
    static string ConvertSMS(string sms)
    {
        if (!string.IsNullOrEmpty(sms))
        {
            string[] lines = sms.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            char[] separatingWordChars = new[] { ' ' };
            string resultSMS = string.Empty;
        
            foreach (string line in lines)
            {
                string[] words = line.Split(separatingWordChars, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 0)
                {
                    foreach (string word in words)
                    {
                        String.IsNullOrEmpty(word);
                        resultSMS += word[0].ToString().ToUpper() + word.Substring(1).ToLower();
                        //resultSMS += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
                    }
                    resultSMS += Environment.NewLine;
                }
            }
            return resultSMS.TrimEnd();
        }
        return sms;
    }
}

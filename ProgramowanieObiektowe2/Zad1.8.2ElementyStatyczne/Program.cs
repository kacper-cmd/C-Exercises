using Zad1._8._2ElementyStatyczne.Helpers;
class Program
{
    static void Main(string[] args)
    {
        var date1 = DateFormatConverter.ConvertToDateInUSFormat("11/22/2024");
        var date2 = DateFormatConverter.ConvertToDateInUSFormat("22/11/2024");

        var date3 = DateFormatConverter.ConvertToDateInPLFormat("22.11.2024");
        var date4 = DateFormatConverter.ConvertToDateInPLFormat("11/22/2024");
        
        var date5 = DateFormatConverter.ConvertToDateInFRFormat("22/11/2024");
        var date6 = DateFormatConverter.ConvertToDateInFRFormat("11.22.2024");
        
        DateFormatConverter.DisplayDetails();
    }
}
using _1_8ElementyStatyczne;

var object1 = new Class1();
Class1.ShowNumberOfObjects();
var object2 = new Class1();
Class1.ShowNumberOfObjects();
var object3 = new Class1();
Class1.ShowNumberOfObjects();
var object4 = new Class1();
Class1.ShowNumberOfObjects();
Console.WriteLine();

var dateText1 = "1 - styczia - 2020";
DateConverter.ConvertPolishDate(dateText1);
var dateText2 = "1 - stycznia - 2020";
DateConverter.ConvertPolishDate(dateText2);
var dateText3 = "1 - december - 2020";
DateConverter.ConvertAmericanDate(dateText3);
var dateText4 = "1 - janvier - 2020";
DateConverter.ConvertFrenchDate(dateText4);
DateConverter.ConvertFrenchDate("");
DateConverter.ConvertFrenchDate("");
DateConverter.ConvertFrenchDate("");
DateConverter.ConvertFrenchDate("");

var dateText5 = "21 - sierpnia - 2022";
var date1 = DateConverter.ConvertPolishDate(dateText5);
var dateText6 = "25 - sierpnia - 2022";
var date2 = DateConverter.ConvertPolishDate(dateText6);
Helper.ShowWorkingDaysBetweenDates(date1, date2);

Helper.DupTheTextInFile(@"D:\WstepDoProgramowania\Programowanie Obiektowe\_1_4Metody\_1_8ElementyStatyczne\TextFile.txt");
Helper.UndupTheTextInFile(@"D:\WstepDoProgramowania\Programowanie Obiektowe\_1_4Metody\_1_8ElementyStatyczne\TextFile.txt");

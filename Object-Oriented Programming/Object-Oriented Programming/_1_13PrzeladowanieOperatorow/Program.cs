using _1_13PrzeladowanieOperatorow;
using _1_3PrzeladowanieOperatorow;

var timeExaple1 = new TimeExample(1, 2, 3);
var timeExaple2 = new TimeExample(10, 20, 30);
Console.WriteLine(timeExaple1 == timeExaple2);
Console.WriteLine(timeExaple1 != timeExaple2);
Console.WriteLine(timeExaple1 > timeExaple2);
Console.WriteLine(timeExaple1 < timeExaple2);
Console.WriteLine(timeExaple1++);
Console.WriteLine(timeExaple2--);
Console.WriteLine();
var numbersA = new int[,] {{1,2,3,4,5},
                           {6,7,8,9,10}};
var numbersB = new int[,] { { 10,9,8,7,6},
    {5,4,3,2,1} };
var numbersC = new int[,] { {1,2,3},
    {3,3,4}};
var matrixA = new Matrix() { Numbers = numbersA };
var matrixB = new Matrix() { Numbers = numbersB };
var matrixC = new Matrix() { Numbers = numbersC };
Console.WriteLine(matrixA + matrixB);
Console.WriteLine(matrixA - matrixB);
Console.WriteLine(matrixC * 2);
Console.WriteLine();
var item1 = new Item(12, "Długopis", 20, 10);
var item2 = new Item(10, "Karktka", 31, 7);
var invoice1 = new Invoice(12, "12.02.2022", "Ambroży", "Grzegorz", new List<Item>() { item1, item2 });
var invoice2 = new Invoice(12, "12.02.2022", "Ambroży", "Grzegorz", new List<Item>() { item1, item2 });
Console.WriteLine(invoice1 == invoice2);
Console.WriteLine(invoice1 <= invoice2);
var invoices = Enumerable.Empty<Invoice>();
invoices = invoices + invoice1;
invoices = invoices + invoice2;
Console.WriteLine(invoice1 & invoices);
;


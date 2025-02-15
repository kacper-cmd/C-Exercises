using BazaDanych.DbConnection;
using BazaDanych.Mapper;
using BazaDanych.Model;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

MapSetter.SetDapperMapper();

var connectionString = @"Server=(localdb)\LibraryDatabase;Database=LibraryDatabase;Trusted_Connection=True;";
var db = new Db(connectionString);

while (true)
{
    Console.WriteLine("Add:");
    Console.WriteLine("  Author - 1");
    Console.WriteLine("  Book - 2");
    Console.WriteLine("  Department - 3");
    Console.WriteLine("  Worker - 4");
    Console.WriteLine("  Wage - 5");
    Console.WriteLine("Coonect Book With Author - 6");
    Console.WriteLine("Display:");
    Console.WriteLine("  BookProperties - 7");
    Console.WriteLine("  WorkerProperties - 8");
    Console.WriteLine("  Authors - 9");
    Console.WriteLine("FindWomen - 0");
    Console.WriteLine("Close app - other key");
    var keyChar = Console.ReadKey().KeyChar;
    Console.Clear();
    switch (keyChar)
    {
        case '1':
            ShowAddAuthorMenu(db);
            break;

        case '2':
            ShowAddBookMenu(db);
            break;

        case '3':
            ShowAddDepartmentMenu(db);
            break;

        case '4':
            ShowAddWorkerMenu(db);
            break;

        case '5':
            ShowAddWageMenu(db);
            break;

        case '6':
            ShowAddBookAuthorMenu(db);
            break;

        case '7':
            ShowBookProperties(db);
            break;

        case '8':
            ShowWorkerProperties(db);
            break;

        case '9':
            ShowAuthors(db);
            break;

        case '0':
            ShowFindWomenMenu(db);
            break;

        default:
            return;
    }
    Thread.Sleep(1000);
    Console.Clear();
}

static void ShowAddAuthorMenu(Db db)
{
    Console.Write("Enter author's name: ");
    var authorName = Console.ReadLine();
    Console.Write("Enter author's surname: ");
    var authorSurname = Console.ReadLine();
    var addAuthorResult = db.AddAuthor(new Author(authorName, authorSurname));
    Console.WriteLine($"Operation {(!addAuthorResult ? "unsuccesfull" : "succesfull")}");
}

static void ShowAddBookMenu(Db db)
{
    Console.Write("Enter book's name: ");
    var bookName = Console.ReadLine();
    Console.Write("Enter department ID: ");
    var departmentId = int.Parse(Console.ReadLine());
    var addBookResult = db.AddBook(new Book(bookName, departmentId));
    Console.WriteLine($"Operation {(!addBookResult ? "unsuccesfull" : "succesfull")}");
}

static void ShowAddDepartmentMenu(Db db)
{
    Console.Write("Enter department's name: ");
    var departmentName = Console.ReadLine();
    var addDepartmentResult = db.AddDepartment(new Department(departmentName));
    Console.WriteLine($"Operation {(!addDepartmentResult ? "unsuccesfull" : "succesfull")}");
}

static void ShowAddWorkerMenu(Db db)
{
    Console.Write("Enter worker's name: ");
    var workerName = Console.ReadLine();
    Console.Write("Enter worker's surname: ");
    var workerSurname = Console.ReadLine();
    var addWorkerResult = db.AddWorker(new Worker(workerName, workerSurname));
    Console.WriteLine($"Operation {(!addWorkerResult ? "unsuccesfull" : "succesfull")}");
}

static void ShowAddWageMenu(Db db)
{
    Console.Write("Enter wage's amount: ");
    decimal workerAmount;
    var workerAmountParsingSucces = decimal.TryParse(Console.ReadLine(), out workerAmount);
    Console.Write("Enter worker's ID: ");
    int workerId;
    var workerIdParsingSucces = int.TryParse(Console.ReadLine(), out workerId);
    var addWageResult = db.AddWage(new Wage(workerAmount, workerId));
    Console.WriteLine($"Operation {(!addWageResult || !workerIdParsingSucces ? "unsuccesfull" : "succesfull")}");
}

static void ShowAddBookAuthorMenu(Db db)
{
    Console.Write("Enter author's ID: ");
    int authorId;
    var authorIdParsingSuccess = int.TryParse(Console.ReadLine(), out authorId);
    Console.Write("Enter books's id: ");
    int bookId;
    var bookIdParsingSuccess = int.TryParse(Console.ReadLine(), out bookId);
    var addBookAuthorResult = db.AddBookAuthor(new BookAuthor(authorId, bookId));
    Console.WriteLine($"Operation " +
        $"{(!addBookAuthorResult || !authorIdParsingSuccess || !bookIdParsingSuccess ? "unsuccesfull" : "succesfull")}");
}

static void ShowBookProperties(Db db)
{
    var bookProperties = db.GetBookProperties();
    foreach (var property in bookProperties)
    {
        Console.WriteLine(property);
    }
    Console.WriteLine("Press any key To exit");
    Console.ReadKey();
}

static void ShowWorkerProperties(Db db)
{
    var workerProperties = db.GetWorkerProperties();
    foreach (var property in workerProperties)
    {
        Console.WriteLine(property);
    }
    Console.WriteLine("Press any key To exit");
    Console.ReadKey();
}

static void ShowAuthors(Db db)
{
    var authors = db.GetAuthors();
    foreach (var author in authors)
    {
        Console.WriteLine(author);
    }
    Console.WriteLine("Press any key To exit");
    Console.ReadKey();
}

static void ShowFindWomenMenu(Db db)
{
    var women = db.FindWomen();
    foreach (var woman in women)
    {
        Console.WriteLine(woman);
    }
    Console.WriteLine("Press any key To exit");
    Console.ReadKey();
}
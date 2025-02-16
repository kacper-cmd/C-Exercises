namespace Queue;

class Program
{
    static void Main(string[] args)
    {
        MyQueue queue = new MyQueue();

        while (true)
        {
            int choice = DisplayMenu();

            WorkWithAChoice(queue, choice);

            BackToMenu();
        }
    }

    private static int DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("\nKolejka MENU (rozmiar -- 20)");
        Console.WriteLine();
        Console.WriteLine("1. Dodaj element.");
        Console.WriteLine("2. Usuń element.");
        Console.WriteLine("3. Zobacz element.");
        Console.WriteLine("4. Wyświetl elementy kolejki.");
        Console.WriteLine("5. Koniec programu");
        Console.WriteLine();
        Console.Write("Dokonaj wyboru co chcesz zrobić: ");
        int.TryParse(Console.ReadLine(), out int result);

        return result;
    }

    private static void WorkWithAChoice(MyQueue queue, int choice)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Wpisz element: ");
                queue.Enqueue(Console.ReadLine());
                break;
            case 2:
                Console.WriteLine("Element usunięty: {0}", queue.Dequeue());
                break;
            case 3:
                Console.WriteLine("Pierwszy element w kolejce to: {0}", queue.Peek());
                break;
            case 4:
                queue.Display();
                break;
            case 5:
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Dokonałeś niewłaściwego wyboru!");
                break;
        }
    }
    private static void BackToMenu()
    {
        Console.WriteLine("Nacisnij Enter aby przejsc do Menu");
        Console.ReadKey();
    }
}
namespace ConsoleApp.MyStack;

using System;

public class Program
{
    static void Main(string[] args)
    {
        MyStack stack = new MyStack();

        while (true)
        {
            int choice = DisplayMenu();

            WorkWithAChoice(stack, choice);

            BackToMenu();
        }
    }

    private static int DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("\nStos MENU (rozmiar -- 10)");
        Console.WriteLine();
        Console.WriteLine("1. Dodaj element.");
        Console.WriteLine("2. Usuń element.");
        Console.WriteLine("3. Zobacz element.");
        Console.WriteLine("4. Wyświetl elementy stosu.");
        Console.WriteLine("5. Koniec programu");
        Console.WriteLine();
        Console.Write("Dokonaj wyboru co chcesz zrobić: ");
        int.TryParse(Console.ReadLine(), out int result);

        return result;
    }

    private static void WorkWithAChoice(MyStack stack, int choice)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Wpisz element: ");
                stack.Push(Console.ReadLine());
                Console.WriteLine("Element został pomyślnie dodany!");
                break;
            case 2:
                Console.WriteLine("Element usunięty: {0}", stack.Pop());
                break;
            case 3:
                Console.WriteLine("Element na szczycie stosu to: {0}", stack.Peek());
                break;
            case 4:
                stack.Display();
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

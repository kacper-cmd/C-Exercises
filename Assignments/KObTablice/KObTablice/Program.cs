namespace KObTabliceZad1;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Podaj wielkość tablicy:");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Podaj element {i + 1}:");
                array[i] = int.Parse(Console.ReadLine());
            }
            int temp;
            while (true)
            {
                Console.WriteLine("\nWybierz operację:");
                Console.WriteLine("1 - Uporządkuj elementy od najmniejszego do największego i wypisanie ich");
                Console.WriteLine("2 - Uporządkuj elementy od największego do najmniejszego i wypisanie ich");
                Console.WriteLine("3 - Wypisz największy i najmniejszy element");
                Console.WriteLine("4 - Wypisz element o podanym indeksie");
                Console.WriteLine("5 - Zastąp element o podanym indeksie nowym elementem");
                Console.WriteLine("6 - Zakończ program");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        // Array.Sort(array);
                        for (int i = 0; i < array.Length ; i++)
                        {
                            for (int j = i + 1; j < array.Length; j++)
                            {
                                if (array[i] > array[j])
                                {
                                    temp = array[i];
                                    array[i] = array[j];
                                    array[j] = temp;
                                }
                            }
                        }
                        Console.WriteLine("Elementy od najmniejszego do największego:");
                        for(int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + (i != array.Length - 1 ? ", " : " "));
                        }
                        Console.WriteLine(string.Join(", ", array));
                        break;
                    case "2":
                        for (int i = 0; i < array.Length ; i++)
                        {
                            for (int j = i + 1; j < array.Length; j++)
                            {
                                if (array[i] < array[j])
                                {

                                    temp = array[i];
                                    array[i] = array[j];
                                    array[j] = temp;
                                }
                            }
                        }
                        //Array.Sort(array);
                        //Array.Reverse(array);
                        Console.WriteLine("Elementy od największego do najmniejszego:");
                        Console.WriteLine(string.Join(", ", array));
                        break;
                    case "3":
                        //int maxElement = array.Max();
                        //int minElement = array.Min();

                        int maxElement = array[0];
                        int minElement = array[0];
                        for (int i = 0; i <= array.Length - 1; i++)
                        {
                            if (array[i] > maxElement)
                            {
                                maxElement = array[i];
                            }
                            if (array[i] < minElement)
                            {
                                minElement = array[i];
                            }
                        }
                        Console.WriteLine($"Największy element: {maxElement}");
                        Console.WriteLine($"Najmniejszy element: {minElement}");
                        break;
                    case "4":
                        Console.WriteLine("Podaj indeks (od 0 do " + (size - 1) + "):");
                        string availableIndexes = string.Empty;
                        for (int i = 0; i < array.Length; i++)
                        {
                            availableIndexes += i + (i != array.Length - 1 ? " ; " : " ");
                        }
                        Console.WriteLine("Dostępne indeksy: " + availableIndexes);
                        int index = int.Parse(Console.ReadLine());
                        if (index >= 0 && index < size)
                        {
                            Console.WriteLine($"Element o indeksie {index}: {array[index]}");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy indeks !!");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Podaj indeks (od 0 do " + (size - 1) + "):");
                        int replaceIndex = int.Parse(Console.ReadLine());
                        if (replaceIndex >= 0 && replaceIndex < size)
                        {
                            Console.WriteLine("Podaj nową wartość:");
                            int newValue = int.Parse(Console.ReadLine());
                            array[replaceIndex] = newValue;
                            Console.WriteLine($"Zastąpiono element o indeksie {replaceIndex} nową wartością: {newValue}");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy indeks");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Koniec programu.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Dozwolono tylko liczby");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

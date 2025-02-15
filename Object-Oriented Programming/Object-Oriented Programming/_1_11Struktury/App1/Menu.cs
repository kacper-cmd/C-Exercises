namespace _1_11Struktury.App1
{
    internal static class Menu
    {
        public static List<Todo> ShowMenu(List<Todo> todos, out bool semaphore)
        {
            semaphore = true;
            Console.WriteLine($"Dodanie TODOsa - 1");
            Console.WriteLine($"Wyświetlenie TODOsów - 2");
            Console.WriteLine($"Usunięcie TODOsa - 3");
            Console.WriteLine($"Wyjście z aplikacji - każdy inny klawisz");
            var taskNumber = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (taskNumber)
            {
                case '1':
                    return AddTodo(todos);

                case '2':
                    DisplayTodos(todos);
                    break;

                case '3':
                    return DeleteTodo(todos);

                default:
                    semaphore = false;
                    break;
            }
            Console.Clear();
            return todos;
        }

        private static List<Todo> AddTodo(List<Todo> todos)
        {
            Console.Write("Podaj tytuł: ");
            var title = Console.ReadLine();

            Console.Write("Podaj datę rozpoczęcia: ");
            var begginingDate = Console.ReadLine();

            Console.Write("Podaj godzinę rozpoczęcia: ");
            var begginingHour = Console.ReadLine();

            Console.Write("Podaj datę zakończenia: ");
            var endingDate = Console.ReadLine();

            Console.Write("Podaj godzinę zakończenia: ");
            var endingHour = Console.ReadLine();

            Console.Write("Podaj komentarz ");
            var comment = Console.ReadLine();

            Console.Write("Podaj nazwę użytkownika: ");
            var nameOfUser = Console.ReadLine();

            Console.Write("Czy użytkownik aktywny [tak/nie]: ");
            var activityOptionText = Console.ReadLine();

            var isActive = true;
            if (activityOptionText.Equals("tak"))
            {
                isActive = true;
            }
            else if (activityOptionText.Equals("nie"))
            {
                isActive = false;
            }
            else
            {
                Console.WriteLine("Złe Dane!");
                Console.Clear();
                return todos;
            }
            var user = new User(nameOfUser, isActive);

            var beggining = new Beggining(begginingDate, begginingHour, user);
            var ending = new Ending(endingDate, endingHour, user);
            var todo = new Todo(title, beggining, ending, comment, user);
            todos.Add(todo);
            Console.Clear();
            return todos;
        }

        private static List<Todo> DeleteTodo(List<Todo> todos)
        {
            Console.Write("Podaj tytuł TODOsa, który chcesz usunąć: ");
            var title = Console.ReadLine();
            var updatedTodos = todos.SkipWhile(t => t.Title.Equals(title)).ToList();
            Console.Clear();
            return updatedTodos;
        }

        private static void DisplayTodos(List<Todo> todos)
        {
            foreach (Todo todo in todos)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Tytuł: {todo.Title}");
                Console.WriteLine();
                Console.Write($"Data rozpoczęcia: {todo.Beggining.BegginingDate}");
                Console.WriteLine();
                Console.Write($"Godzinę rozpoczęcia: {todo.Beggining.BegginingHour}");
                Console.WriteLine();
                Console.Write($"Podaj datę zakończenia: {todo.Ending.EndingDate}");
                Console.WriteLine();
                Console.Write($"Podaj godzinę zakończenia: {todo.Ending.EndingHour}");
                Console.WriteLine();
                Console.Write($"Podaj komentarz {todo.Comment}");
                Console.WriteLine();
                Console.Write($"Podaj nazwę użytkownika: {todo.User.Name}");
                Console.WriteLine();
                Console.Write($"Użytkownik {(todo.User.IsActive ? "" : "nie")} aktywny");
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine($"Naciśnij klawisz aby wyjść");
            Console.ReadKey();
        }
    }
}
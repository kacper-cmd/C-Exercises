using System;
using System.Text;

class Program
{
    #region Structs
    struct User
    {
        public string Name;
        public bool IsActive;
    }
    struct TaskTime
    {
        public DateTime Date;
        public TimeSpan Hour;
        public User User;
    }
    struct Task
    {
        public string Title;
        public TaskTime Start;
        public TaskTime End;
        public string Comment;
        public User AssignUserToTask;
    }

    static List<Task> tasks = new List<Task>();

    #endregion

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("TO-DO");
            Console.Write("Please enter number : \n");
            Console.WriteLine("1. -> Add");
            Console.WriteLine("2. -> Browse");
            Console.WriteLine("3. -> Delete");
            Console.WriteLine("4. -> TO Exit");

            var userChoice = Console.ReadLine();

            try
            {
                switch (userChoice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        BrowseTasks();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please try again !");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    #region Methods
    private static void AddTask()
    {
        Task newTask = new Task();

        Console.Write("Enter task title: ");
        newTask.Title = Console.ReadLine();

        var user = GetUser("responsible for whole task");
        newTask.AssignUserToTask = user;

        newTask.Start = GetDateTimeInfo("responsible for starting the task (who begin it)");
        newTask.End = GetDateTimeInfo("responsible for ending the task (who end it)");

        Console.Write("Enter task comment: ");
        newTask.Comment = Console.ReadLine();

        tasks.Add(newTask);
        Console.WriteLine("Task added successfully.");
    }
    static TaskTime GetDateTimeInfo(string type)
    {
        TaskTime dateTime = new TaskTime();
        
        Console.Write($"Enter date of user {type} (yyyy-mm-dd): ");
        var userDate = Console.ReadLine();

        if (DateTime.TryParse(userDate, out DateTime date))
        {
            dateTime.Date = date;
        }
        else
        {
            throw new FormatException("Invalid date not in (yyyy-mm-dd) format");
        }

        Console.Write($"Enter {type} time (HH:mm): ");
        var userHour = Console.ReadLine();

        if (TimeSpan.TryParse(userHour, out TimeSpan hours))
        {
            dateTime.Hour = hours;
        }
        else
        {
            throw new FormatException("Invalid hours not in HH:mm format");
        }
        var user = GetUser(type);
        dateTime.User = user;

        return dateTime;
    }
    static User GetUser(string type)
    {
        User user = new User();

        Console.Write($"Enter user name {type}: ");
        user.Name = Console.ReadLine();

        Console.Write($"Is {user.Name} user active? -> (true/false): ");
        
        var userActive = Console.ReadLine();
        
        if (bool.TryParse(userActive, out bool active))
        {
            user.IsActive = active;
        }
        else
        {
            throw new FormatException("You should enter true or false !");
        }

        return user;
    }
    static void DeleteTask()
    {
        Console.Write("Enter the task number in order to delete: ");
        var userTaskNumber = Console.ReadLine();

        int taskNumber;
        if (int.TryParse(userTaskNumber, out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task deleted! ");
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid task number.");
        }
    }
    private static void BrowseTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("-- No tasks --");
            return;
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < tasks.Count; i++)
        {
            Task task = tasks[i];
            sb.AppendLine($"Task {i + 1}:");
            sb.AppendLine($"Title: {task.Title}");
            sb.AppendLine($"Start Date: {task.Start.Date.ToShortDateString()}, Start Time: {task.Start.Hour}, User which started: {task.Start.User.Name}, Active: {task.Start.User.IsActive}");
            sb.AppendLine($"End Date: {task.End.Date.ToShortDateString()}, End Time: {task.End.Hour}, User which end : {task.End.User.Name}, Active: {task.End.User.IsActive}");
            sb.AppendLine($"Comment: {task.Comment}");
            sb.AppendLine($"User which is assign : {task.AssignUserToTask.Name}, Active: {task.AssignUserToTask.IsActive}");
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }
    #endregion
}
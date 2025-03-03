// Dowódca
class CommanderComposite : IUnitComponent
{
    // Lista wszystkich dzieci przypisanych do dowódcy
    private List<IUnitComponent> _children = new List<IUnitComponent>();

    // Rozkaz do ruszenia się
    public void Move()
    {
        Console.WriteLine("I'm a commander and i go first");

        foreach (var item in _children)
        {
            item.Move();
        }
    }

    // Metoda dodająca dzieci
    public void AddChild(IUnitComponent entity)
    {
        _children.Add(entity);
    }

    // Metoda usuwająca dzieci
    public void RemoveChild(IUnitComponent entity)
    {
        _children.Remove(entity);
    }

    // Metoda pobierająca dzieci
    public List<IUnitComponent> GetChild()
    {
        return _children;
    }
}

// interface po którym dziedziczy każdy komponent
interface IUnitComponent
{
    void Move();
}

// Konkretna jednostka
class EntityLeaf : IUnitComponent
{
    // Rozkaz do ruszenia się
    public void Move()
    {
        Console.WriteLine("I move after my commander");
    }
}

// Główna klasa w aplikacji konsolowej "Klient"
class Program
{
    static void Main(string[] args)
    {
        // Powołanie do życia dowódcy.
        CommanderComposite commander = new CommanderComposite();

        // Dodanie jednostek do dowódcy
        commander.AddChild(new EntityLeaf());
        commander.AddChild(new EntityLeaf());
        commander.AddChild(new EntityLeaf());
        commander.AddChild(new EntityLeaf());
        commander.AddChild(new EntityLeaf());

        // Wydanie rozkazu do poruszenia
        commander.Move();

        // Zatrzymanie programu
        Console.Read();
    }
}

// Przykładowe zadania jakie jednostki mogą wykonać
public enum Request
{
    House,
    Portal,
    Attack
}

// Główna klasa aplikacji konsolowej
class Program
{
    static void Main(string[] args)
    {

        List<Unit> selectedUnits = new List<Unit>();

        // Przez to, że nie wiemy jakie obiekty znajdują się w zaznaczeniu
        // dokonujemy symulacji takiej sytuacji
        // poniżej dodaje obiekty do listy
        selectedUnits.Add(new Worker());
        selectedUnits.Add(new Warrior());
        selectedUnits.Add(new Mag());

        // Przeszukuje listę wszystkich zaznaczonych jednostek 
        // a następnie dokonuję powiazuje ich ze soba w lańcuch
        for (int i = 0; i < selectedUnits.Count - 1; i++)
        {
            selectedUnits[i].setNumber(selectedUnits[i + 1]);
        }

        // Zadania do wykonania
        List<Request> Requests = new List<Request> {
            Request.House,
            Request.Portal,
            Request.Attack
        };

        // Wysłanie żądań
        foreach (var request in Requests)
        {
            selectedUnits[0].HandleRequest(request);
        }

        // Zatrzymanie aplikacji
        Console.ReadKey();
    }
}

// Abstrakcyjna klasa odpowiedzialna za połączenie klas w łańcuch
abstract class Unit
{
    protected Unit unit;

    public void setNumber(Unit unit)
    {
        this.unit = unit;
    }

    public abstract void HandleRequest(Request request);
}

// Konkretny handler czyli klasa, która przetwarza żądanie lub wysyła dalej
class Worker : Unit
{
    // sprawdzanie czy klasa jest w stanie przetworzyć żądanie czy wysłać je dalej
    public override void HandleRequest(Request request)
    {
        if (request == Request.House)
        {
            Console.WriteLine("The worker start making a house");
        }
        else if (unit != null)
        {
            unit.HandleRequest(request);
        }
    }
}

// Konkretny handler czyli klasa, która przetwarza żądanie lub wysyła dalej
class Warrior : Unit
{
    //sprawdzanie czy klasa jest w stanie przetworzyć żądanie czy wysłać je dalej
    public override void HandleRequest(Request request)
    {
        if (request == Request.Attack)
        {
            Console.WriteLine("The warrior start attacking");
        }
        else if (unit != null)
        {
            unit.HandleRequest(request);
        }
    }
}

// Konkretny handler czyli klasa, która przetwarza żądanie lub wysyła dalej
class Mag : Unit
{
    //sprawdzanie czy klasa jest w stanie przetworzyć żądanie czy wysłać je dalej
    public override void HandleRequest(Request request)
    {
        if (request == Request.Portal)
        {
            Console.WriteLine("The mag start casting a portal");
        }
        else if (unit != null)
        {
            unit.HandleRequest(request);
        }
    }
}

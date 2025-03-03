// Dyrektor
class GameDirector
{
    // Wydanie polecenia zbudowania poziomu krok po kroku
    public void BuildLevel(ILevelBuilder levelBuilder)
    {
        levelBuilder.AddFloor();
        levelBuilder.AddEnvironment();
        levelBuilder.AddNpc();
    }
}

// Zespół programistów 
// interface po którym dziedziczą konkretni budowniczy
interface ILevelBuilder
{
    void AddFloor();
    void AddNpc();
    void AddEnvironment();
}

// Konkretny Budowniczy 1
class IceLevelConcreteBuilder : ILevelBuilder
{
    private Level level = new Level();

    public void AddEnvironment()
    {
        level.AddEnvironment("Ice blocks");
    }

    public void AddFloor()
    {
        level.AddFloor("Slippery floor");
    }

    public void AddNpc()
    {
        level.AddNpc("Ice mag");
    }

    public Level GetLevel()
    {
        return this.level;
    }
}

// Konkretny Budowniczy 2
class FireLevelConcreteBuilder : ILevelBuilder
{
    private Level level = new Level();

    public void AddEnvironment()
    {
        level.AddEnvironment("Red blocks");
    }

    public void AddFloor()
    {
        level.AddFloor("Hot floor");
    }

    public void AddNpc()
    {
        level.AddNpc("Fenix");
    }

    public Level GetLevel()
    {
        return this.level;
    }
}

// Produkt
class Level
{
    private string environment;
    private string floor;
    private string npc;

    public void AddEnvironment(string environment)
    {
        this.environment = environment;
    }

    public void AddFloor(string floor)
    {
        this.floor = floor;
    }

    public void AddNpc(string npc)
    {
        this.npc = npc;
    }

    public void Show()
    {
        Console.WriteLine(this.environment);
        Console.WriteLine(this.floor);
        Console.WriteLine(this.npc);
    }
}

// Główna klasa w aplikacji consolowej
class Program
{
    // Główna metoda aplikacji
    static void Main(string[] args)
    {
        // Tworzenie dyrektora i konkretnych budowniczych
        GameDirector director = new GameDirector();

        FireLevelConcreteBuilder fireLevel = new FireLevelConcreteBuilder();
        IceLevelConcreteBuilder iceLevel = new IceLevelConcreteBuilder();

        // Tworzenie dwóch poziomów i wypisanie wiadomości o nich
        Console.WriteLine("Fire Level:");
        director.BuildLevel(fireLevel);
        Level level = fireLevel.GetLevel();
        level.Show();

        Console.WriteLine("Ice Level:");
        director.BuildLevel(iceLevel);
        Level level2 = iceLevel.GetLevel();
        level2.Show();

        // Czekanie na reakcje użytkownika
        Console.ReadLine();
    }
}

// The Product
public class Pizza
{
    private String size;
    private bool cheese;
    private bool pepperoni;
    private bool mushrooms;

    public Pizza(String size, bool cheese, bool pepperoni, bool mushrooms)
    {
        this.size = size;
        this.cheese = cheese;
        this.pepperoni = pepperoni;
        this.mushrooms = mushrooms;
    }

    public void showDetails()
    {
        Console.WriteLine("Pizza Size: " + size);
        Console.WriteLine("Cheese: " + (cheese ? "Yes" : "No"));
        Console.WriteLine("Pepperoni: " + (pepperoni ? "Yes" : "No"));
        Console.WriteLine("Mushrooms: " + (mushrooms ? "Yes" : "No"));
    }
}

// The Builder
public class PizzaBuilder
{
    private String size;
    private bool cheese;
    private bool pepperoni;
    private bool mushrooms;
                 
    public PizzaBuilder(String size)
    {
        this.size = size;
    }

    public PizzaBuilder addCheese()
    {
        this.cheese = true;
        return this;
    }

    public PizzaBuilder addPepperoni()
    {
        this.pepperoni = true;
        return this;
    }

    public PizzaBuilder addMushrooms()
    {
        this.mushrooms = true;
        return this;
    }

    public Pizza build()
    {
        return new Pizza(size, cheese, pepperoni, mushrooms);
    }
}

// Usage
public class Main
{
    public static void main(String[] args)
    {
        Pizza pizza = new PizzaBuilder("Medium")
                          .addCheese()
                          .addPepperoni()
                          .build();
        pizza.showDetails();
    }
}

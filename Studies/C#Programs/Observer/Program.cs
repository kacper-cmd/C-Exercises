using Observer;

class Program
{
    static void Main(string[] args)
    {
        DummyProduct prod = new DummyProduct();
        // Ustalamy 4 sklepy, które będą stosowały zaktualizowane ceny
        Shop shop1 = new Shop("Shop1");
        Shop shop2 = new Shop("Shop2");
        Shop shop3 = new Shop("Shop3");
        Shop shop4 = new Shop("Shop4");
        // Dodajemy dwa sklepy dla 1 sposobu
        prod.Attach(shop1);
        prod.Attach(shop2);
        // Dodajemy dwa sklepy dla 2 sposobu
        prod.Attach2(shop3);
        prod.Attach2(shop4);
        // Zmienimy teraz cenę produktu, powinna zmienić się automatycznie we wszystkich sklepach
        prod.ChangePrice(23.0f);
        // Teraz usuniemy dwa sklepy, którymi się nie interesujemy
        prod.Detach(shop2);
        prod.Detach2(shop4);
        // A następnie ponownie zmienimy cenę
        prod.ChangePrice(8.0f);
        Console.ReadKey();
    }
}
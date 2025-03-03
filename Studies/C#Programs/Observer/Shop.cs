using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer;
class Shop : IObserver
{
    string name;
    float price = 0.0f; // wartość domyślna
    public Shop(string name)
    {
        this.name = name;
    }
    public void Update(float price)
    {
        this.price = price;
        Console.WriteLine($"Cena produktu {this.name} to {this.price}");
    }
}
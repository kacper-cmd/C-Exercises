using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
   
class Product
{
    string name;
    decimal price;
    float vat;

    public Product(string n, decimal p, float v) { name = n; price = p; vat = v; }
    public void print() { Console.WriteLine("{0}, {1}zł, vat {2:p}", name, price, vat); }
}


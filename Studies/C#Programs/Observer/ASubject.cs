using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer;
class ASubject
{
    // Pierwszy sposób implementacji (1)
    ArrayList list = new ArrayList();
    // Drugi sposób implementacji (2)
    public delegate void StatusUpdate(float price);
    public event StatusUpdate OnStatusUpdate = null;
    public void Attach(Shop product)
    {
        // dodajemy obserwatora dla sposobu nr 1
        list.Add(product);
    }
    public void Detach(Shop product)
    {
        // usuwamy obserwatora z naszej listy dla sposobu 1
        list.Remove(product);
    }
    public void Attach2(Shop product)
    {
        // dodajemy obserwatora dla sposobu nr 2
        OnStatusUpdate += new StatusUpdate(product.Update);
    }
    public void Detach2(Shop product)
    {
        // usuwamy obserwatora dla sposobu 2
        OnStatusUpdate -= new StatusUpdate(product.Update);
    }
    public void Notify(float price)
    {
        // dla pierwszego sposobu informujemy obserwatora o zmianie
        foreach (Shop p in list)
        {
            p.Update(price);
        }
        // dla drugiego sposobu informujemy obserwatora o zmianie
        if (OnStatusUpdate != null)
            OnStatusUpdate(price);
    }
}